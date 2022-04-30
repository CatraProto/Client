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
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Updates;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.Updates
{
    public class DifferenceTools
    {
        public static void GetDifferenceChanges(IObject differenceBase, out IList<MessageBase> newMessages, out IList<EncryptedMessageBase> newEncryptedMessages, out IList<UpdateBase> newUpdates, out IList<ChatBase> chats, out IList<UserBase> users, out StateBase state)
        {
            switch (differenceBase)
            {
                case Difference difference:
                    newMessages = difference.NewMessages;
                    newEncryptedMessages = difference.NewEncryptedMessages;
                    newUpdates = difference.OtherUpdates;
                    chats = difference.Chats;
                    users = difference.Users;
                    state = difference.State;
                    return;
                case DifferenceSlice differenceSlice:
                    newMessages = differenceSlice.NewMessages;
                    newEncryptedMessages = differenceSlice.NewEncryptedMessages;
                    newUpdates = differenceSlice.OtherUpdates;
                    chats = differenceSlice.Chats;
                    users = differenceSlice.Users;
                    state = differenceSlice.IntermediateState;
                    return;
                default:
                    throw new InvalidOperationException($"This difference {differenceBase} result can't be extracted");
            }
        }
    }
}