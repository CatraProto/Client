using System;
using System.Buffers;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.Crypto;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.RpcErrors;
using CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors.Files;
using CatraProto.Client.TL.Schemas.CloudChats;
using Serilog;

namespace CatraProto.Client.ApiManagers.Files.Upload;

public class FileUploadSession : IDisposable
{
    private const int MaxConnectionsCount = 4;
    private const int MaxChunks = 8000;
    private const long MaxUploadSize = (long)MaxChunks * 1024 * 1024;
    private const int BigFileLength = 10 * 1024 * 1024;

    public long UploadId { get; }
    private readonly FileProgressInvoker? _fileProgressInvoker;
    private readonly object _mutex = new object();
    private readonly ArrayPool<byte> _arrayPool;
    private readonly TelegramClient _client;
    private readonly long _fileLength;
    private ConnectionItem[]? _connectionItem;
    private readonly UploadProxyStream _sourceStream;
    private readonly ChunkSize _chunkSize;
    private readonly int _numberOfChunks;
    private readonly ILogger _logger;
    private readonly bool _isBig;
    private readonly bool _isPhoto;
    private int _currentAt;

    private FileUploadSession(TelegramClient client, Stream stream, long fileLength, FileProgressCallback? callback, bool isPhoto = false)
    {
        _client = client;
        _fileLength = fileLength;
        UploadId = CryptoTools.CreateRandomLong();
        _logger = client.GetLogger<FileUploadSession>().ForContext<FileUploadSession>().ForContext("FileId", UploadId);
        _sourceStream = new UploadProxyStream(stream, fileLength);
        _isPhoto = isPhoto;
        _isBig = fileLength > BigFileLength;
        _chunkSize = GetChunkSize(stream.Length);
        _arrayPool = ArrayPool<byte>.Create((int)_chunkSize, (int)_chunkSize / 1024);
        _numberOfChunks = (int)(fileLength / (int)_chunkSize);
        _numberOfChunks += fileLength % (int)_chunkSize > 0 ? 1 : 0;

        if (callback is not null)
        {
            _fileProgressInvoker = new FileProgressInvoker(callback, _logger);
        }
    }

    public static RpcResponse<FileUploadSession> Create(TelegramClient client, Stream stream, long fileLength, FileProgressCallback? callback, bool isPhoto)
    {
        if (stream.Length > MaxUploadSize)
        {
            return RpcResponse<FileUploadSession>.FromError(new FileTooBigError());
        }

        return RpcResponse<FileUploadSession>.FromResult(new FileUploadSession(client, stream, fileLength, callback, isPhoto));
    }

    public async Task<RpcResponse<bool>> UploadFileAsync(CancellationToken cancellationToken = default)
    {
        var connectionsCount = _fileLength > BigFileLength ? MaxConnectionsCount : 1;
        _connectionItem ??= new ConnectionItem[connectionsCount];
        var tasks = new Task<ConnectionItem>[connectionsCount];

        for (int i = 0; i < _connectionItem.Length; i++)
        {
            tasks[i] = _client.ClientSession.ConnectionPool.GetConnectionByDcAsync(-1, _connectionItem.Length > 1, true, cancellationToken);
        }

        for (int i = 0; i < _connectionItem.Length; i++)
        {
            _connectionItem[i] = await tasks[i];
        }

        var parallelOptions = new ParallelOptions
        {
            CancellationToken = cancellationToken,
            MaxDegreeOfParallelism = connectionsCount * (2 << 15 / (int)_chunkSize) * 2
        };

        try
        {
            _logger.Information("Starting upload. Number of chunks {NumberOfChunks}", _numberOfChunks);
            await Parallel.ForEachAsync(Enumerable.Range(0, _numberOfChunks), parallelOptions, async (chunk, parallelToken) =>
            {
                await SendChunkAsync(chunk, true, parallelToken);
            });
            _logger.Information("Finished upload. Number of chunks {NumberOfChunks}", _numberOfChunks);
        }
        catch (RpcException e)
        {
            // Even though exceptions are bad to control the flow, this is the easiest way to interrupt the parallel operation when something goes wrong. 
            // When an operation inside Parallel throws an exception, the cancellationToken passed to the lambda gets canceled as well.
            // Another possibility would be to create a linked cancellation token that gets canceled when something goes wrong, but we'd achieve the exact same behavior
            // with the exact same tools (exceptions) but with added complexity and overhead
            return RpcResponse<bool>.FromError(e.RpcError);
        }

        return RpcResponse<bool>.FromResult(true);
    }

    public InputFileBase GetInputFile()
    {
        var fileName = _isPhoto ? UploadId + ".jpg" : UploadId.ToString();
        return _isBig ? new InputFileBig(UploadId, _numberOfChunks, fileName) : new InputFile(UploadId, _numberOfChunks, fileName, string.Empty);
    }

    public Task<RpcResponse<bool>> SendChunkAsync(int chunkNumber, CancellationToken cancellationToken = default)
    {
        return SendChunkAsync(chunkNumber, false, cancellationToken);
    }

    private async Task<RpcResponse<bool>> SendChunkAsync(int chunkNumber, bool throwInsteadOfReturn, CancellationToken cancellationToken)
    {
        _logger.Information("Trying to send chunk {Chunk}", chunkNumber);

        var api = _connectionItem![GetConnectionIndex()].Connection.MtProtoState.Api;
        var chunkStartOffset = (long)chunkNumber * (int)_chunkSize;
        var endsAt = chunkStartOffset + (int)_chunkSize;

        if (chunkStartOffset > _fileLength)
        {
            _logger.Error("Tried to send part {PartNumber} but it doesn't exist", chunkNumber);
            return RpcResponse<bool>.FromError(new UnknownError("FILE_PART_NOT_FOUND", 404));
        }

        if (endsAt > _fileLength)
        {
            endsAt -= endsAt - _fileLength;
        }

        var chunkLength = (int)(endsAt - chunkStartOffset);
        GetBuffer(chunkLength, out var buffer, out var mustReturn);
        try
        {
            _logger.Information("Retrieving chunk {Chunk} from offset {Offset} with length {Length}", chunkNumber, chunkStartOffset, chunkLength);
            await PullChunkAsync(buffer, chunkStartOffset, cancellationToken);

            _logger.Information("Started uploading chunk {Chunk}", chunkNumber);
            RpcResponse<bool> response;
            if (_isBig)
            {
                response = await api.CloudChatsApi.Upload.SaveBigFilePartAsync(UploadId, chunkNumber, _numberOfChunks, buffer, cancellationToken: cancellationToken);
            }
            else
            {
                response = await api.CloudChatsApi.Upload.SaveFilePartAsync(UploadId, chunkNumber, buffer, cancellationToken: cancellationToken);
            }

            if (response.RpcCallFailed)
            {
                _logger.Error("Failed to upload file chunk {Chunk}. The following error occured: {Error}", chunkNumber, response.Error);
                if (throwInsteadOfReturn)
                {
                    var unused = response.Response;
                }

                return RpcResponse<bool>.FromError(response.Error);
            }

            _logger.Information("Successfully uploaded file chunk {Chunk}", chunkNumber);
            _fileProgressInvoker?.Invoke(chunkLength);
            return response;
        }
        catch (RpcException)
        {
            throw;
        }
        catch (Exception e)
        {
            if (e is OperationCanceledException opCancelled && opCancelled.CancellationToken == cancellationToken)
            {
                _logger.Information("Stopping upload of file chunk {Chunk} because the operation was cancelled", chunkNumber);
                throw;
            }

            _logger.Error(e, "Failed to upload file chunk {Chunk}. An exception was thrown", chunkNumber);
            throw;
        }
        finally
        {
            if (mustReturn)
            {
                _arrayPool.Return(buffer);
            }
        }
    }

    private async Task PullChunkAsync(byte[] buffer, long startAt, CancellationToken cancellationToken)
    {
        await _sourceStream.ReadDataAsync(buffer, buffer.Length, startAt, cancellationToken);
    }

    private void GetBuffer(int size, out byte[] buffer, out bool mustReturn)
    {
        if (size == (int)_chunkSize)
        {
            mustReturn = true;
            buffer = _arrayPool.Rent((int)_chunkSize);
        }
        else
        {
            mustReturn = false;
            buffer = new byte[size];
        }
    }

    private int GetConnectionIndex()
    {
        lock (_mutex)
        {
            if (_currentAt == _connectionItem!.Length - 1)
            {
                _currentAt = 0;
            }
            else
            {
                _currentAt++;
            }

            return _currentAt;
        }
    }

    private static ChunkSize GetChunkSize(long length)
    {
        return length switch
        {
            < 1 * 1024 * 1024 => ChunkSize.TinyDocument,
            <= 32 * 1024 * 1024 => ChunkSize.LittleDocument,
            <= 375 * 1024 * 1024 => ChunkSize.SmallDocument,
            <= 750 * 1024 * 1024 => ChunkSize.MediumDocument,
            <= 1500 * 1024 * 1024 => ChunkSize.LargeDocument,
            _ => ChunkSize.LargeDocument
        };
    }

    public void Dispose()
    {
        if (_connectionItem is not null)
        {
            for (int i = 0; i < _connectionItem.Length; i++)
            {
                _connectionItem[i].ReturnToPool();
            }
        }

        _sourceStream.Dispose();
    }
}