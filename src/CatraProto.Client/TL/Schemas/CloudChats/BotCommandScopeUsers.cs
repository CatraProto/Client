using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class BotCommandScopeUsers : CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopeBase
    {
        public static int StaticConstructorId
        {
            get => 1011811544;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public BotCommandScopeUsers()
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
            return "botCommandScopeUsers";
        }
    }
}