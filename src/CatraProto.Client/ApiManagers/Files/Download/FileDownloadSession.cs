using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Locks;
using CatraProto.Client.Connections;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors.Files;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Upload;
using Serilog;
using File = CatraProto.Client.TL.Schemas.CloudChats.Upload.File;

namespace CatraProto.Client.ApiManagers.Files.Download;

internal class FileDownloadSession : IDisposable
{
    private const int MaxConnectionsCount = 4;
    private const int OneMB = 1024 * 1024;

    private readonly DownloadProxyStream _destinationStream;
    private readonly FileProgressInvoker? _fileProgressInvoker;
    private readonly ConnectionItem[] _connectionItems;
    private readonly int _numberOfChunks;

    // Don't make read-only because struct would get copied on every call
    private FileLocation _fileLocation;
    private InputFileLocationBase? _inputFileLocation;
    private readonly TelegramClient _client;
    private readonly FileDownloadOptions _options;
    private readonly ILogger _logger;
    private readonly object _mutex = new object();
    private readonly AsyncLock _fileReferenceLock = new AsyncLock();
    private int _currentAt;

    private FileDownloadSession(TelegramClient client, Stream destinationStream, long size, FileDownloadOptions options, FileLocation fileLocation, FileProgressCallback? callback)
    {
        _client = client;
        _options = options;
        _logger = client.GetLogger<FileDownloadSession>().ForContext("FileId", _fileLocation.Id);
        _destinationStream = new DownloadProxyStream(destinationStream);
        _fileLocation = fileLocation;
        _numberOfChunks = (int)(size / OneMB);
        _numberOfChunks += size % OneMB > 0 ? 1 : 0;
        _connectionItems = new ConnectionItem[size > OneMB * 10 ? MaxConnectionsCount : 1];
        if (callback is not null)
        {
            _fileProgressInvoker = new FileProgressInvoker(callback, _logger);
        }
    }

    public static RpcResponse<FileDownloadSession> Create(TelegramClient client, Stream destinationStream, FileDownloadOptions options, FileLocation fileLocation, FileProgressCallback? callback)
    {
        if (options.PhotoSize is not null)
        {
            if (fileLocation.StaticSizes?.Where(x => x.Compare(options.PhotoSize)).FirstOrDefault() is null)
            {
                return RpcResponse<FileDownloadSession>.FromError(new InvalidStaticSizeError());
            }

            return RpcResponse<FileDownloadSession>.FromResult(new FileDownloadSession(client, destinationStream, options.PhotoSize.Size, options, fileLocation, callback));
        }

        if (options.VideoSize is not null)
        {
            if (fileLocation.VideoSizes?.Where(x => x.Compare(options.VideoSize)).FirstOrDefault() is null)
            {
                return RpcResponse<FileDownloadSession>.FromError(new InvalidVideoSizeError());
            }

            return RpcResponse<FileDownloadSession>.FromResult(new FileDownloadSession(client, destinationStream, options.VideoSize.Size, options, fileLocation, callback));
        }

        return RpcResponse<FileDownloadSession>.FromResult(new FileDownloadSession(client, destinationStream, fileLocation.Size, options, fileLocation, callback));
    }

    public async Task<RpcResponse<bool>> DownloadFileAsync(CancellationToken cancellationToken = default)
    {
        _logger.Information("Creating {Count} connections to DC {DcId}", _connectionItems.Length, _fileLocation.DcId);
        for (int i = 0; i < _connectionItems.Length; i++)
        {
            _connectionItems[i] = await _client.ClientSession.ConnectionPool.GetConnectionByDcAsync(_fileLocation.DcId, _connectionItems.Length > 1, true, cancellationToken);
        }

        var parallelOptions = new ParallelOptions
        {
            CancellationToken = cancellationToken,
            MaxDegreeOfParallelism = _connectionItems.Length
        };

        var getInput = _fileLocation.GetInputFile(_options);
        if (getInput.RpcCallFailed)
        {
            return RpcResponse<bool>.FromError(getInput.Error);
        }

        _inputFileLocation = getInput.Response;
        _logger.Information("Starting download with max degree of parallelism set to {MaxDegree}", parallelOptions.MaxDegreeOfParallelism);
        try
        {
            await Parallel.ForEachAsync(Enumerable.Range(0, _numberOfChunks), parallelOptions, async (i, token) =>
            {
                await DownloadFilePartAsync(i, token);
            });

            _logger.Information("Finished downloading file");
        }
        catch (RpcException e)
        {
            _logger.Information("File download failed due to error {Error}", e.RpcError);
            return RpcResponse<bool>.FromError(e.RpcError);
        }

        return RpcResponse<bool>.FromResult(true);
    }

    private async Task DownloadFilePartAsync(int part, CancellationToken token)
    {
        while (true)
        {
            var refToOldLocation = _inputFileLocation;
            _logger.Information("Requesting file part {Part} at offset {Offset} of size {Size}", part, part * OneMB, OneMB);
            var getFile = await _connectionItems[GetConnectionIndex()].Connection.MtProtoState.Api.CloudChatsApi.Upload.GetFileAsync(refToOldLocation!, part * OneMB, OneMB, true, false, new MessageSendingOptions(TimeSpan.FromMinutes(1)), cancellationToken: token);
            if (getFile.RpcCallFailed)
            {
                _logger.Information("Received error for file part {Part}. Error: {Error}", part, getFile.Error.ToString());
                if (getFile.Error.ErrorMessage.StartsWith("FILE_REFERENCE_"))
                {
                    var throwIfError = (await RestoreContextAsync(token, FileTools.GetFileReference(refToOldLocation!))).Response;
                    continue;
                }

                // Throw error when it can't be recovered, will be catch-ed by caller
                var unused = getFile.Response;
            }

            if (getFile.Response is FileCdnRedirect)
            {
                _logger.Error("Received fileCdnRedirect");
                throw new InvalidOperationException("Server returned file cdn redirect");
            }

            var bytes = ((File)getFile.Response).Bytes;
            await _destinationStream.WriteChunkAsync(part, bytes, token);
            _fileProgressInvoker?.Invoke(bytes.Length);
            return;
        }
    }

    private async Task<RpcResponse<bool>> RestoreContextAsync(CancellationToken cancellationToken, byte[] usedFileReference)
    {
        using (await _fileReferenceLock.LockAsync(cancellationToken))
        {
            if (!usedFileReference.SequenceEqual(_fileLocation.FileReference))
            {
                _logger.Information("No need to refresh file reference because an old one was used");
                return RpcResponse<bool>.FromResult(true);
            }

            _logger.Information("Refreshing file reference");
            var response = await FileLocation.RefreshFileReferenceAsync(_client, _fileLocation, cancellationToken);
            if (response.RpcCallFailed)
            {
                return RpcResponse<bool>.FromError(response.Error);
            }

            _fileLocation = response.Response;
            var tryGetFileLoc = _fileLocation.GetInputFile(_options);
            if (tryGetFileLoc.RpcCallFailed)
            {
                return RpcResponse<bool>.FromError(tryGetFileLoc.Error);
            }

            _inputFileLocation = tryGetFileLoc.Response;
            return RpcResponse<bool>.FromResult(true);
        }
    }

    private int GetConnectionIndex()
    {
        lock (_mutex)
        {
            if (_currentAt == _connectionItems!.Length - 1)
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

    public void Dispose()
    {
        foreach (var t in _connectionItems)
        {
            t.ReturnToPool();
        }

        _destinationStream.Dispose();
        _fileReferenceLock.Dispose();
    }
}