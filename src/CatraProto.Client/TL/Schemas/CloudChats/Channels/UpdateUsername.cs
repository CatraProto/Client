using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class UpdateUsername : IMethod<bool>
    {
        public static int ConstructorId { get; } = 890549214;
        public InputChannelBase Channel { get; set; }
        public string Username { get; set; }

        public Type Type { get; init; } = typeof(UpdateUsername);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
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