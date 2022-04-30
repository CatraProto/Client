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
using System.Threading.Tasks;

namespace CatraProto.Client.Async.Loops.Extensions
{
    public static class LoopExtensions
    {
        public static async Task<bool> TrySignalAsync<TLoopState, TSignalState>(this LoopController<TLoopState, TSignalState> loopController, TSignalState signal) where TLoopState : Enum where TSignalState : Enum
        {
            if (!loopController.SendSignal(signal, out var task))
            {
                return false;
            }

            await task;
            return true;
        }

        public static Task SignalAsync<TLoopState, TSignalState>(this LoopController<TLoopState, TSignalState> loopController, TSignalState signal) where TLoopState : Enum where TSignalState : Enum
        {
            if (!loopController.SendSignal(signal, out var task))
            {
                throw new InvalidOperationException("Failed to send signal");
            }

            return task;
        }
    }
}