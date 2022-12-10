// CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
// Copyright (C) 2022 Aquatica <aquathing@protonmail.com>
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// You should have received a copy of the GNU Lesser General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.


using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.ApiManagers.Files.Download;
using CatraProto.Client.ApiManagers.Files.Updates;
using CatraProto.Client.ApiManagers.Files.Upload;
using CatraProto.Client.ApiManagers.Files.UploadMetadata;
using CatraProto.Client.Async.Locks;
using CatraProto.Client.MTProto;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors;
using CatraProto.Client.MTProto.Rpc.RpcErrors.Files;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.Tools;

namespace CatraProto.Client.ApiManagers.Files;

public class FileManager
{
    private const int BigFileLength = 10 * 1024 * 1024;

    private readonly AsyncLock _downloadLock = new AsyncLock();
    private readonly AsyncLock _uploadLock = new AsyncLock();
    private readonly SequentialInvoker _sequentialInvoker;
    private readonly TelegramClient _client;

    public FileManager(TelegramClient client)
    {
        _sequentialInvoker = new SequentialInvoker(client.GetLogger<FileManager>());
        _client = client;
    }

    public async Task<RpcResponse<bool>> DownloadFileAsync(FileId fileId, Stream destination, FileDownloadOptions? options = null, FileProgressCallback? fileProgressCallback = null, CancellationToken cancellationToken = default)
    {
        if (fileId == null)
        {
            throw new ArgumentNullException(nameof(fileId));
        }

        if (destination == null)
        {
            throw new ArgumentNullException(nameof(destination));
        }

        options ??= new FileDownloadOptions();
        IDisposable? lockHandle = null;
        try
        {
            var size = options.PhotoSize?.Size ?? options.VideoSize?.Size ?? fileId.BackingFileLocation.Size;
            if (size > BigFileLength)
            {
                lockHandle = await _downloadLock.LockAsync(cancellationToken);
            }

            var createSession = FileDownloadSession.Create(_client, destination, options, fileId.BackingFileLocation, fileProgressCallback);
            if (createSession.RpcCallFailed)
            {
                return RpcResponse<bool>.FromError(createSession.Error);
            }

            using var session = createSession.Response;
            return await session.DownloadFileAsync(cancellationToken);
        }
        finally
        {
            lockHandle?.Dispose();
        }
    }

    // TODO: Create alternatives to inputMediaUploadedDocument and inputMediaUploadedPhoto 
    internal async Task<RpcResponse<FileUploadSession>> UploadFileAsync(Stream fileStream, long? readUntil = null, FileProgressCallback? fileProgressCallback = null, bool isPhoto = false, CancellationToken cancellationToken = default)
    {
        IDisposable? lockHandle = null;
        try
        {
            var size = readUntil ?? fileStream.Length - fileStream.Position;
            if (size > BigFileLength)
            {
                lockHandle = await _uploadLock.LockAsync(cancellationToken);
            }

            var createSession = FileUploadSession.Create(_client, fileStream, size, fileProgressCallback, isPhoto);
            if (createSession.RpcCallFailed)
            {
                return RpcResponse<FileUploadSession>.FromError(createSession.Error);
            }

            await createSession.Response.UploadFileAsync(cancellationToken);
            return RpcResponse<FileUploadSession>.FromResult(createSession.Response);
        }
        finally
        {
            lockHandle?.Dispose();
        }
    }

    public async Task<RpcResponse<Document>> UploadDocumentAsync(PeerId targetChat, Stream documentStream, UploadOptions uploadOptions, CancellationToken cancellationToken = default)
    {
        if (uploadOptions.UploadMetadata is not UploadMetadataDocument metadataDocument)
        {
            throw new InvalidOperationException("A metadata object of type UploadMetadataDocument is required");
        }

        var tryUploadFile = await UploadFileAsync(documentStream, uploadOptions.ReadUntil, uploadOptions.Callback, false, cancellationToken);
        if (tryUploadFile.RpcCallFailed)
        {
            return RpcResponse<Document>.FromError(tryUploadFile.Error);
        }

        InputFileBase? thumb = null;
        if (metadataDocument.Thumb is not null)
        {
            var tryUploadThumb = await UploadFileAsync(metadataDocument.Thumb, uploadOptions.ReadUntil, uploadOptions.Callback, false, cancellationToken);
            if (tryUploadThumb.RpcCallFailed)
            {
                return RpcResponse<Document>.FromError(tryUploadThumb.Error);
            }

            thumb = tryUploadThumb.Response.GetInputFile();
        }

        var inputUploadDoc = new InputMediaUploadedDocument(tryUploadFile.Response.GetInputFile(), metadataDocument.MimeType, metadataDocument.Attributes)
        {
            Thumb = thumb,
            NosoundVideo = metadataDocument.NoSound,
            TtlSeconds = metadataDocument.TtlSeconds,
            ForceFile = metadataDocument.ForceFile,
            Stickers = metadataDocument.Stickers,
        };

        var uploadMedia = await UploadMediaAsync(tryUploadFile.Response, targetChat, inputUploadDoc, cancellationToken);
        if (uploadMedia.Response is MessageMediaDocument { Document: Document document })
        {
            return RpcResponse<Document>.FromResult(document);
        }

        return RpcResponse<Document>.FromError(new InvalidTypeError());
    }

    public async Task<RpcResponse<Photo>> UploadPhotoAsync(PeerId targetChat, Stream documentStream, UploadOptions uploadOptions, CancellationToken cancellationToken = default)
    {
        if (uploadOptions.UploadMetadata is not UploadMetadataPhoto metadataPhoto)
        {
            throw new InvalidOperationException("A metadata object of type UploadMetadataPhoto is required");
        }

        var tryUploadFile = await UploadFileAsync(documentStream, uploadOptions.ReadUntil, uploadOptions.Callback, true, cancellationToken);
        if (tryUploadFile.RpcCallFailed)
        {
            return RpcResponse<Photo>.FromError(tryUploadFile.Error);
        }

        var inputUploadDoc = new InputMediaUploadedPhoto(tryUploadFile.Response.GetInputFile())
        {
            TtlSeconds = metadataPhoto.TtlSeconds,
            Stickers = metadataPhoto.Stickers,
        };

        var uploadMedia = await UploadMediaAsync(tryUploadFile.Response, targetChat, inputUploadDoc, cancellationToken);
        if (uploadMedia.Response is MessageMediaPhoto { Photo: Photo photo })
        {
            return RpcResponse<Photo>.FromResult(photo);
        }

        return RpcResponse<Photo>.FromError(new InvalidTypeError());
    }

    private async Task<RpcResponse<MessageMediaBase>> UploadMediaAsync(FileUploadSession uploadSession, PeerId targetChat, InputMediaBase inputMediaBase, CancellationToken cancellationToken)
    {
        while (true)
        {
            var uploadMedia = await _client.Api.CloudChatsApi.Messages.UploadMediaAsync(targetChat, inputMediaBase, cancellationToken: cancellationToken);
            if (!uploadMedia.RpcCallFailed)
            {
                return uploadMedia;
            }

            if (uploadMedia.Error is FilePartMissing part)
            {
                var tryReupload = await uploadSession.SendChunkAsync(part.ChunkNumber, cancellationToken);
                if (tryReupload.RpcCallFailed)
                {
                    return RpcResponse<MessageMediaBase>.FromError(tryReupload.Error);
                }
            }
            else
            {
                return RpcResponse<MessageMediaBase>.FromError(uploadMedia.Error);
            }
        }
    }

    internal void NotifyNewFileId(byte[] oldFileId, byte[] newFileId)
    {
        _sequentialInvoker.Invoke(() =>
        {
            var eventHandler = _client.EventHandler;
            return eventHandler is null ? Task.CompletedTask : eventHandler.OnUpdateFileId(new UpdateFileId(new FileId(oldFileId), new FileId(newFileId)));
        });
    }
}