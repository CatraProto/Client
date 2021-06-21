using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class LangPackString : LangPackStringBase
    {
        public static int ConstructorId { get; } = -892239370;
        public override string Key { get; set; }
        public string Value { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Key);
            writer.Write(Value);
        }

        public override void Deserialize(Reader reader)
        {
            Key = reader.Read<string>();
            Value = reader.Read<string>();
        }
    }
}