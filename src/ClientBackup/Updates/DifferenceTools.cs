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