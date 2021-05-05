using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class EditTitle : IMethod<UpdatesBase>
    {
        public static int ConstructorId { get; } = 1450044624;
        public InputChannelBase Channel { get; set; }
        public string Title { get; set; }

        public Type Type { get; init; } = typeof(EditTitle);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Channel);
            writer.Write(Title);
        }

        public void Deserialize(Reader reader)
        {
            Channel = reader.Read<InputChannelBase>();
            Title = reader.Read<string>();
        }
    }
}