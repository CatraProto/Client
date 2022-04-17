using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class PrivacyRules : CatraProto.Client.TL.Schemas.CloudChats.Account.PrivacyRulesBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1352683077; }

        [Newtonsoft.Json.JsonProperty("rules")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.PrivacyRuleBase> Rules { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public PrivacyRules(List<CatraProto.Client.TL.Schemas.CloudChats.PrivacyRuleBase> rules, List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Rules = rules;
            Chats = chats;
            Users = users;

        }
#nullable disable
        internal PrivacyRules()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkrules = writer.WriteVector(Rules, false);
            if (checkrules.IsError)
            {
                return checkrules;
            }
            var checkchats = writer.WriteVector(Chats, false);
            if (checkchats.IsError)
            {
                return checkchats;
            }
            var checkusers = writer.WriteVector(Users, false);
            if (checkusers.IsError)
            {
                return checkusers;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryrules = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PrivacyRuleBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryrules.IsError)
            {
                return ReadResult<IObject>.Move(tryrules);
            }
            Rules = tryrules.Value;
            var trychats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trychats.IsError)
            {
                return ReadResult<IObject>.Move(trychats);
            }
            Chats = trychats.Value;
            var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryusers.IsError)
            {
                return ReadResult<IObject>.Move(tryusers);
            }
            Users = tryusers.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.privacyRules";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}