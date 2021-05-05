using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class EditPhoto : IMethod<UpdatesBase>
    {
        public static int ConstructorId { get; } = -248621111;
        public InputChannelBase Channel { get; set; }
        public InputChatPhotoBase Photo { get; set; }

        public Type Type { get; init; } = typeof(EditPhoto);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Channel);
            writer.Write(Photo);
        }

        public void Deserialize(Reader reader)
        {
            Channel = reader.Read<InputChannelBase>();
            Photo = reader.Read<InputChatPhotoBase>();
        }
    }
}