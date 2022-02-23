using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PrivacyValueDisallowChatParticipants : CatraProto.Client.TL.Schemas.CloudChats.PrivacyRuleBase
    {
        public static int StaticConstructorId
        {
            get => 1103656293;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("chats")]
        public IList<long> Chats { get; set; }


    #nullable enable
        public PrivacyValueDisallowChatParticipants(IList<long> chats)
        {
            Chats = chats;
        }
    #nullable disable
        internal PrivacyValueDisallowChatParticipants()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Chats);
        }

        public override void Deserialize(Reader reader)
        {
            Chats = reader.ReadVector<long>();
        }

        public override string ToString()
        {
            return "privacyValueDisallowChatParticipants";
        }
    }
}