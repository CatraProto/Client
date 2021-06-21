using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using CatraProto.Client.Async.Locks;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.Connections
{
	internal class MessagesHandler : IDisposable
	{
		public int OutgoingCount
		{
			get => _outgoingMessages.Reader.Count;
		}
		
		private readonly ILogger _logger;
		private MessageContainer _oldMessage;
		private Channel<MessageContainer> _outgoingMessages = Channel.CreateUnbounded<MessageContainer>();
		private ConcurrentDictionary<long, MessageContainer> _sentMessages = new ConcurrentDictionary<long, MessageContainer>();
		private AsyncLock _unencryptedMessagesLock = new AsyncLock();

		public MessagesHandler(ILogger logger)
		{
			_logger = logger.ForContext<MessagesHandler>();
		}

		public Task<MessageContainer> ListenAsync(CancellationToken cancellationToken)
		{
			return _outgoingMessages.Reader.ReadAsync(cancellationToken).AsTask();
		}

		public async Task<Task> EnqueueMessage(OutgoingMessage message, IRpcMessage rpcContainer)
		{
			var completionSource = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
			var messageContainer = new MessageContainer
			{
				OutgoingMessage = message,
				CompletionSource = completionSource,
				RpcContainer = rpcContainer
			};
			
			if(!message.IsEncrypted)
			{
				//This deserves an explanation:
				//UnencryptedMessages aren't identifiable by their MessageId since it is not persistent,
				//therefore, the best way to complete the correct task is to send one message after the previous one received a response
				_logger.Information("Enqueuing unencrypted message, acquiring lock...");
				using (await _unencryptedMessagesLock.LockAsync())
				{
					_logger.Information("Lock acquired for unencrypted message");
					if (_oldMessage != null)
					{
						_logger.Information("An old unencrypted message hasn't yet received a response, waiting before enqueueing this one...");
						try
						{
							await _oldMessage.CompletionSource.Task;
						}
						finally
						{
							_logger.Information("The old message received a response or got cancelled, proceeding to enqueue...");
						}
					}

					if (message.MessageOptions.ExpectsResponse)
					{
						_oldMessage = messageContainer;
					}
				}
			}

			if (message.CancellationToken.IsCancellationRequested)
			{
				//This is because the registration doesn't get called if the token is already cancelled
				_logger.Information("Cancellation of the message got requested just before registering a callback, cancelling...");
				DequeueMessage(messageContainer, message.CancellationToken);
				return Task.FromCanceled(message.CancellationToken);
			}

			messageContainer.CancellationTokenRegistration = message.CancellationToken.Register(() => DequeueMessage(messageContainer, message.CancellationToken));
			_outgoingMessages.Writer.TryWrite(messageContainer);
			_logger.Information("{Type} message enqueued successfully", message.IsEncrypted ? "Encrypted" : "Unencrypted");
			return completionSource.Task;
		}

		public void DequeueMessage(MessageContainer message, CancellationToken? token = null)
		{
			_logger.Information("Dequeuing message {Message}, IsEncrypted: {Encrypted}, CancellationRequested: {Requested}", message.OutgoingMessage.Body, message.OutgoingMessage.IsEncrypted, token != null);
			if (token != null)
			{
				message.CompletionSource.TrySetCanceled(token.Value);
			}
			else
			{
				message.CompletionSource.TrySetCanceled();
			}

			message.CancellationTokenRegistration.Unregister();
		}

		public void SetMessageCompletion(long messageId, object response)
		{
			var isEncrypted = messageId != 0;
			if (isEncrypted)
			{
				if (_sentMessages.TryGetValue(messageId, out var container))
				{
					container.RpcContainer.SetResponse(response);
					container.CancellationTokenRegistration.Unregister();
					container.CompletionSource.TrySetResult();
					_logger.Information("Completed task for message {Id}. Received: {Type}", messageId, response.ToString());
				}
				else
				{
					_logger.Warning("Can't complete messageId {Id}. Message not found", messageId);
				}
			}
			else
			{
				if (_oldMessage != null)
				{
					_oldMessage.RpcContainer.SetResponse(response);
					_oldMessage.CompletionSource.TrySetResult();
					_oldMessage.CancellationTokenRegistration.Unregister();
					_logger.Information("Completed task for unencryptedMessage, received: {Type}", response.ToString());
				}
				else
				{
					_logger.Warning("Can't complete unencrypted task, no old task was found. Received type: {Type}", response.ToString());
				}
			}
		}

		public bool AddSentMessage(long messageId, MessageContainer message)
		{
			return _sentMessages.TryAdd(messageId, message);
		}

		public bool GetMethod(long messageId, out IMethod method)
		{
			if (_sentMessages.TryGetValue(messageId, out var container))
			{
				if (container.OutgoingMessage.Body is IMethod outMethod)
				{
					method = outMethod;
					return true;
				}
				else
				{
					_logger.Warning("Requested messageId {Id} is not a method", messageId);
				}
			}
			else
			{
				_logger.Warning("Couldn't find messageId {Id}", messageId);
			}

			method = null;
			return false;
		}
		
		public void Dispose()
		{
			_unencryptedMessagesLock?.Dispose();
		}
	}
}