using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class DataJSON : DataJSONBase
    {
        public static int ConstructorId { get; } = 2104790276;
        public override string Data { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Data);
        }

        public override void Deserialize(Reader reader)
        {
            Data = reader.Read<string>();
        }
    }
}