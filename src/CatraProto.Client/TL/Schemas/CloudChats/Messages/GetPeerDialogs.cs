using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetPeerDialogs : IMethod
    {
        public static int ConstructorId { get; } = -462373635;
        public IList<InputDialogPeerBase> Peers { get; set; }

        public Type Type { get; init; } = typeof(PeerDialogsBase);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Peers);
        }

        public void Deserialize(Reader reader)
        {
            Peers = reader.ReadVector<InputDialogPeerBase>();
        }
    }
}