using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class GetNotifySettings : IMethod<PeerNotifySettingsBase>
    {
        public static int ConstructorId { get; } = 313765169;
        public InputNotifyPeerBase Peer { get; set; }

        public Type Type { get; init; } = typeof(GetNotifySettings);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Peer);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputNotifyPeerBase>();
        }
    }
}