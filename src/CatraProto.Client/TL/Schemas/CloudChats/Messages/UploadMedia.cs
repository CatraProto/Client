using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class UploadMedia : IMethod
    {
        public static int ConstructorId { get; } = 1369162417;
        public InputPeerBase Peer { get; set; }
        public InputMediaBase Media { get; set; }

        public Type Type { get; init; } = typeof(MessageMediaBase);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Peer);
            writer.Write(Media);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputPeerBase>();
            Media = reader.Read<InputMediaBase>();
        }
    }
}