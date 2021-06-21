using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class JsonString : JSONValueBase
    {
        public static int ConstructorId { get; } = -1222740358;
        public string Value { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Value);
        }

        public override void Deserialize(Reader reader)
        {
            Value = reader.Read<string>();
        }
    }
}