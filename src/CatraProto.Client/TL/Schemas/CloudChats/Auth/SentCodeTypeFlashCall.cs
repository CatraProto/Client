using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class SentCodeTypeFlashCall : SentCodeTypeBase
    {
        public static int ConstructorId { get; } = -1425815847;
        public string Pattern { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Pattern);
        }

        public override void Deserialize(Reader reader)
        {
            Pattern = reader.Read<string>();
        }
    }
}