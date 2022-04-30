/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Collections;
using CatraProto.Client.Async.Signalers.Interfaces;

namespace CatraProto.Client.Async.Signalers
{
    public class AsyncStateSignaler<T> : IStateSignaler<T>, IDisposable
    {
        private readonly EqualityComparer<T> _equalityComparer = EqualityComparer<T>.Default;
        private readonly AsyncQueue<T> _asyncQueue = new AsyncQueue<T>();
        private readonly object _mutex = new object();
        private CancellationToken? _cancellationToken;
        private bool _isObjectDisposed;

        public AsyncStateSignaler(T? initialState)
        {
            if (initialState is not null)
            {
                _asyncQueue.Enqueue(initialState);
            }
        }

        public void Signal(T state, bool force)
        {
            lock (_mutex)
            {
                ThrowIfDisposed();
                if (_asyncQueue.TryGetLastEnqueued(out var lastState))
                {
                    if (_equalityComparer.Equals(state, lastState) && !force)
                    {
                        return;
                    }
                }

                _asyncQueue.Enqueue(state);
            }
        }

        public void Signal(T state)
        {
            lock (_mutex)
            {
                Signal(state, false);
            }
        }

        public T? GetLastSignaled()
        {
            lock (_mutex)
            {
                _asyncQueue.TryGetLastEnqueued(out var item);
                return item;
            }
        }

        public T? GetCurrentState(bool setAsRead)
        {
            lock (_mutex)
            {
                ThrowIfDisposed();
                T? toReturn;
                if (_asyncQueue.TryPeek(out var item))
                {
                    toReturn = item!;
                    if (setAsRead)
                    {
                        _asyncQueue.Dequeue();
                    }
                }
                else
                {
                    _asyncQueue.TryGetLastDequeued(out var last);
                    return last;
                }

                return toReturn;
            }
        }

        public Task<T> WaitAsync(CancellationToken token = default)
        {
            ValueTask<T> task;
            lock (_mutex)
            {
                ThrowIfDisposed();
                task = _asyncQueue.DequeueAsync(token);
            }


            return task.AsTask();
        }

        public async ValueTask<T> WaitStateAsync(bool alwaysWait, CancellationToken token = default, params T[] targetStates)
        {
            //No need to lock here, the signaler is designed to have only one reader at a time
            if (!alwaysWait && GetCurrentState(false) is not null)
            {
                var currentState = GetCurrentState(true);
                if (IsStateInArray(targetStates, currentState!, out var foundState))
                {
                    return foundState!;
                }
            }

            while (true)
            {
                //this actually will set it as read no matter what, but it does not matter
                var currentState = await WaitAsync(token);
                if (IsStateInArray(targetStates, currentState, out var foundState))
                {
                    return foundState!;
                }
            }
        }

        private bool IsStateInArray(T[] states, T targetState, [MaybeNullWhen(false)] out T foundState)
        {
            foreach (var state in states)
            {
                if (!_equalityComparer.Equals(state, targetState))
                {
                    continue;
                }

                foundState = state;
                return true;
            }

            foundState = default;
            return false;
        }

        private void ThrowIfDisposed()
        {
            lock (_mutex)
            {
                if (!_isObjectDisposed)
                {
                    return;
                }

                if (_cancellationToken != null)
                {
                    throw new OperationCanceledException(_cancellationToken.Value);
                }
                else
                {
                    throw new ObjectDisposedException("AsyncStateSignaler");
                }
            }
        }

        public void SetCancellationToken(CancellationToken cancellationToken)
        {
            lock (_mutex)
            {
                ThrowIfDisposed();
                _cancellationToken = cancellationToken;
            }
        }

        public void Dispose()
        {
            lock (_mutex)
            {
                _isObjectDisposed = true;
                _asyncQueue.Dispose();
            }
        }
    }
}