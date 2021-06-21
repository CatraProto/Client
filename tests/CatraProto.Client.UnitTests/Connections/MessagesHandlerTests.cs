using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using Serilog;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace CatraProto.Client.UnitTests.Connections
{
    public class MessagesHandlerTests
    {
        private readonly ILogger _logger;

        public MessagesHandlerTests(ITestOutputHelper testOutputHelper)
        {
            _logger = SerilogLogger.CreateLogger(testOutputHelper);
            _logger.ForContext<MessagesHandlerTests>();
        }

        [Fact]
        public async Task DuplicateTest()
        {
            using (var messagesHandler = new CatraProto.Client.Connections.MessagesHandler(_logger))
            {
                var outgoingMessage = new OutgoingMessage
                {
                    IsEncrypted = true
                };
                await messagesHandler.EnqueueMessage(outgoingMessage, new RpcMessage<object>());
                await Assert.ThrowsAsync<InvalidOperationException>(() => messagesHandler.EnqueueMessage(outgoingMessage, new RpcMessage<object>()));
            }
        }
        
        [Fact]
        public async Task SchedulingTests()
        {
            using (var messagesHandler = new CatraProto.Client.Connections.MessagesHandler(_logger))
            {
                var outgoingMessages = new List<OutgoingMessage>();
                var cancellationTokens = new List<CancellationTokenSource>();
                for (int i = 0; i < 3; i++)
                {
                    var tokenSource = new CancellationTokenSource();
                    var outgoingMessage = new OutgoingMessage
                    {
                        IsEncrypted = true,
                        CancellationToken = tokenSource.Token
                    };
                    cancellationTokens.Add(tokenSource);
                    outgoingMessages.Add(outgoingMessage);
                    await messagesHandler.EnqueueMessage(outgoingMessage, new RpcMessage<object>());
                }

                _logger.Information("Checking whether the number of scheduled messages is 3");
                Assert.Equal(3, messagesHandler.OutgoingCount);

                _logger.Information("Cancelling the first message, bringing the count to 2");
                cancellationTokens[0].Cancel();
                Assert.Equal(2, messagesHandler.OutgoingCount);

                _logger.Information("Now pulling two messages out of the scheduler");
                for (int i = 0; i < 2; i++)
                {
                    var timeoutToken = new CancellationTokenSource();
                    timeoutToken.CancelAfter(TimeSpan.FromSeconds(2));
                
                    try
                    {
                        var message = await messagesHandler.ListenAsync(timeoutToken.Token);
                        Assert.Same(outgoingMessages[i + 1], message);
                    }
                    catch (OperationCanceledException e)
                    {
                        if (e.CancellationToken == timeoutToken.Token)
                        {
                            throw new XunitException("Timeout expired before pulling the message out");
                        }
                    }
                }
            }
        }
    }
}