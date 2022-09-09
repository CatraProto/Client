using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Bots
{
    public partial class GetBotCommands : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -481554986; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("scope")]
        public CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopeBase Scope { get; set; }

        [Newtonsoft.Json.JsonProperty("lang_code")]
        public string LangCode { get; set; }


#nullable enable
        public GetBotCommands(CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopeBase scope, string langCode)
        {
            Scope = scope;
            LangCode = langCode;
        }
#nullable disable

        internal GetBotCommands()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkscope = writer.WriteObject(Scope);
            if (checkscope.IsError)
            {
                return checkscope;
            }

            writer.WriteString(LangCode);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryscope = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopeBase>();
            if (tryscope.IsError)
            {
                return ReadResult<IObject>.Move(tryscope);
            }

            Scope = tryscope.Value;
            var trylangCode = reader.ReadString();
            if (trylangCode.IsError)
            {
                return ReadResult<IObject>.Move(trylangCode);
            }

            LangCode = trylangCode.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "bots.getBotCommands";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetBotCommands();
            var cloneScope = (CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopeBase?)Scope.Clone();
            if (cloneScope is null)
            {
                return null;
            }

            newClonedObject.Scope = cloneScope;
            newClonedObject.LangCode = LangCode;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetBotCommands castedOther)
            {
                return true;
            }

            if (Scope.Compare(castedOther.Scope))
            {
                return true;
            }

            if (LangCode != castedOther.LangCode)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}