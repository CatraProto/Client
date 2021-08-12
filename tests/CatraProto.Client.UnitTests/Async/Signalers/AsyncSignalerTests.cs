using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Signalers;
using Xunit;

namespace CatraProto.Client.UnitTests.Async.Signalers
{
    public enum State
    {
        FirstState,
        SecondState,
    }

    public class AsyncSignaler
    {
        [Fact]
        public void GetCurrentStateNotRemoving()
        {
            var signaler = new AsyncStateSignaler<State>(State.FirstState);
            signaler.Signal(State.SecondState);
            Assert.StrictEqual(State.FirstState, signaler.GetCurrentState(false));
            Assert.StrictEqual(State.FirstState, signaler.GetCurrentState(true));
            Assert.StrictEqual(State.SecondState, signaler.GetCurrentState(true));
        }

        [Fact]
        public void DisposingReturnsToken()
        {
            var signaler = new AsyncStateSignaler<State>(State.FirstState);
            var cancellationToken = new CancellationToken();
            signaler.SetCancellationToken(cancellationToken);
            signaler.Dispose();
            var caught = Assert.Throws<OperationCanceledException>(() => signaler.GetCurrentState(false));
            Assert.Equal(caught.CancellationToken, cancellationToken);
        }

        [Fact]
        public void DisposingReturnsObjectDisposed()
        {
            var signaler = new AsyncStateSignaler<State>(State.FirstState);
            signaler.Dispose();
            var caught = Assert.Throws<ObjectDisposedException>(() => signaler.GetCurrentState(false));
            Assert.Equal("AsyncStateSignaler", caught.ObjectName);
        }

        [Fact]
        public async Task DisposingReturnsObjectDisposedAsync()
        {
            var signaler = new AsyncStateSignaler<State>(State.FirstState);
            signaler.Dispose();
            var caught = await Assert.ThrowsAsync<ObjectDisposedException>(() => signaler.WaitAsync());
            Assert.Equal("AsyncStateSignaler", caught.ObjectName);
        }

        [Fact]
        public async Task DisposingReturnsOperationCanceledAsync()
        {
            var signaler = new AsyncStateSignaler<State>(State.FirstState);
            var cancellationToken = new CancellationToken();
            signaler.SetCancellationToken(cancellationToken);
            signaler.Dispose();

            // ReSharper disable once MethodSupportsCancellation
            var caught = await Assert.ThrowsAsync<OperationCanceledException>(() => signaler.WaitAsync());
            Assert.Equal(caught.CancellationToken, cancellationToken);
        }
    }
}