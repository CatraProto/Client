using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InlineQueryPeerTypeMegagroup : CatraProto.Client.TL.Schemas.CloudChats.InlineQueryPeerTypeBase
    {
        public static int StaticConstructorId
        {
            get => 1589952067;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public InlineQueryPeerTypeMegagroup()
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
            return "inlineQueryPeerTypeMegagroup";
        }
    }
}