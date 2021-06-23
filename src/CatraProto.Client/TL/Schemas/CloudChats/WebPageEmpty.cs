using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class WebPageEmpty : WebPageBase
    {
        public static int ConstructorId { get; } = -350980120;
        public long Id { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Id);
        }

        public override void Deserialize(Reader reader)
        {
            Id = reader.Read<long>();
        }
    }
}