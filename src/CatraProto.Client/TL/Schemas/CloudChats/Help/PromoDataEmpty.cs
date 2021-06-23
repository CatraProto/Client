using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public class PromoDataEmpty : PromoDataBase
    {
        public static int ConstructorId { get; } = -1728664459;
        public override int Expires { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Expires);
        }

        public override void Deserialize(Reader reader)
        {
            Expires = reader.Read<int>();
        }
    }
}