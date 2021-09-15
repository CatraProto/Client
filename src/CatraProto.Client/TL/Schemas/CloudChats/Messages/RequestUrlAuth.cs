using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class RequestUrlAuth : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -482388461;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(UrlAuthResultBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("peer")] public InputPeerBase Peer { get; set; }

        [JsonProperty("msg_id")] public int MsgId { get; set; }

        [JsonProperty("button_id")] public int ButtonId { get; set; }

        public override string ToString()
        {
            return "messages.requestUrlAuth";
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
            writer.Write(MsgId);
            writer.Write(ButtonId);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputPeerBase>();
            MsgId = reader.Read<int>();
            ButtonId = reader.Read<int>();
        }
    }
}