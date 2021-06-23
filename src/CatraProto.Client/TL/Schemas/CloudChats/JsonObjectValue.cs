using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class JsonObjectValue : JSONObjectValueBase
    {
        public static int ConstructorId { get; } = -1059185703;
        public override string Key { get; set; }
        public override JSONValueBase Value { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Key);
            writer.Write(Value);
        }

        public override void Deserialize(Reader reader)
        {
            Key = reader.Read<string>();
            Value = reader.Read<JSONValueBase>();
        }
    }
}