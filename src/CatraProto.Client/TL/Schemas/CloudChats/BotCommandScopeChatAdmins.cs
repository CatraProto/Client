using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class BotCommandScopeChatAdmins : CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopeBase
    {
        public static int StaticConstructorId
        {
            get => -1180016534;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public BotCommandScopeChatAdmins()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
        }

        public override void Deserialize(Reader reader)
        {
        }

        public override string ToString()
        {
            return "botCommandScopeChatAdmins";
        }
    }
}