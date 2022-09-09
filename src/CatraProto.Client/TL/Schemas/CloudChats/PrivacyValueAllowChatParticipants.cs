using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PrivacyValueAllowChatParticipants : CatraProto.Client.TL.Schemas.CloudChats.PrivacyRuleBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1796427406; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public List<long> Chats { get; set; }


#nullable enable
        public PrivacyValueAllowChatParticipants(List<long> chats)
        {
            Chats = chats;
        }
#nullable disable
        internal PrivacyValueAllowChatParticipants()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteVector(Chats, false);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trychats = reader.ReadVector<long>(ParserTypes.Int64);
            if (trychats.IsError)
            {
                return ReadResult<IObject>.Move(trychats);
            }

            Chats = trychats.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "privacyValueAllowChatParticipants";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PrivacyValueAllowChatParticipants();
            newClonedObject.Chats = new List<long>();
            foreach (var chats in Chats)
            {
                newClonedObject.Chats.Add(chats);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PrivacyValueAllowChatParticipants castedOther)
            {
                return true;
            }

            var chatssize = castedOther.Chats.Count;
            if (chatssize != Chats.Count)
            {
                return true;
            }

            for (var i = 0; i < chatssize; i++)
            {
                if (castedOther.Chats[i] != Chats[i])
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}