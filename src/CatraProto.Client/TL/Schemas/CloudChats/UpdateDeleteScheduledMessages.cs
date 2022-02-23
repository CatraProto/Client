using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateDeleteScheduledMessages : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        public static int StaticConstructorId
        {
            get => -1870238482;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("messages")]
        public IList<int> Messages { get; set; }


    #nullable enable
        public UpdateDeleteScheduledMessages(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer, IList<int> messages)
        {
            Peer = peer;
            Messages = messages;
        }
    #nullable disable
        internal UpdateDeleteScheduledMessages()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Peer);
            writer.Write(Messages);
        }

        public override void Deserialize(Reader reader)
        {
            Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            Messages = reader.ReadVector<int>();
        }

        public override string ToString()
        {
            return "updateDeleteScheduledMessages";
        }
    }
}