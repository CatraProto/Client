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
using System.Threading.Tasks;
using Serilog;

namespace CatraProto.Client.Tools
{
    internal class SequentialInvoker
    {
        private readonly Queue<Func<Task>> _queuedTasks = new Queue<Func<Task>>();
        private readonly object _mutex = new object();
        private bool _currentlyWaiting = false;
        private readonly ILogger _logger;

        public SequentialInvoker(ILogger logger)
        {
            _logger = logger.ForContext<SequentialInvoker>();
        }

        private void OnInvokingDone()
        {
            lock (_mutex)
            {
                _currentlyWaiting = false;
                if (_queuedTasks.Count > 0)
                {
                    Invoke(_queuedTasks.Dequeue());
                }
            }
        }

        public void Invoke(Func<Task> task, bool wait = true)
        {
            lock (_mutex)
            {
                if (_currentlyWaiting && wait)
                {
                    _queuedTasks.Enqueue(task);
                    return;
                }

                _currentlyWaiting = true;
                Task.Run(async () =>
                {
                    try
                    {
                        await task();
                    }
                    catch (Exception e)
                    {
                        _logger.Error(e, "Exception thrown on user-provided callback");
                    }
                    finally
                    {
                        OnInvokingDone();
                    }
                });
            }
        }
    }
}
