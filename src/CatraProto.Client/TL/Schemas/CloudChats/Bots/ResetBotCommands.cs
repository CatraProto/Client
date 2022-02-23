using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Bots
{
    public partial class ResetBotCommands : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1032708345;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(bool);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("scope")]
        public CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopeBase Scope { get; set; }

        [Newtonsoft.Json.JsonProperty("lang_code")]
        public string LangCode { get; set; }


    #nullable enable
        public ResetBotCommands(CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopeBase scope, string langCode)
        {
            Scope = scope;
            LangCode = langCode;
        }
    #nullable disable

        internal ResetBotCommands()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Scope);
            writer.Write(LangCode);
        }

        public void Deserialize(Reader reader)
        {
            Scope = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopeBase>();
            LangCode = reader.Read<string>();
        }

        public override string ToString()
        {
            return "bots.resetBotCommands";
        }
    }
}