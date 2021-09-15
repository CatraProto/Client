using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class GetNotifySettings : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 313765169;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(PeerNotifySettingsBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("peer")] public InputNotifyPeerBase Peer { get; set; }

        public override string ToString()
        {
            return "account.getNotifySettings";
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

            writer.Write(Peer);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputNotifyPeerBase>();
        }
    }
}