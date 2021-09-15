using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetPeerDialogs : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -462373635;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(PeerDialogsBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("peers")] public IList<InputDialogPeerBase> Peers { get; set; }

        public override string ToString()
        {
            return "messages.getPeerDialogs";
        }


        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Peers);
        }

        public void Deserialize(Reader reader)
        {
            Peers = reader.ReadVector<InputDialogPeerBase>();
        }
    }
}