using System;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.Tools
{
    public class MessageTools
    {
        public static string ExtractMessageFromMethod(IMethod method)
        {
            switch (method)
            {
                case SendMessage sendMessage:
                    return sendMessage.Message;
                case EditMessage editMessage:
                    return editMessage.Message;
                default:
                    throw new InvalidOperationException($"Type {method} is not supported");
            }
        }
    }
}