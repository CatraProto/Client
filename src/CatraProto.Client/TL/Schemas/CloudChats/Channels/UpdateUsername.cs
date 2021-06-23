using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public class UpdateUsername : IMethod
    {
        public static int ConstructorId { get; } = 890549214;

        public Type Type { get; init; } = typeof(bool);
        public bool IsVector { get; init; } = false;
        public InputChannelBase Channel { get; set; }
        public string Username { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Channel);
            writer.Write(Username);
        }

        public void Deserialize(Reader reader)
        {
            Channel = reader.Read<InputChannelBase>();
            Username = reader.Read<string>();
        }
    }
}