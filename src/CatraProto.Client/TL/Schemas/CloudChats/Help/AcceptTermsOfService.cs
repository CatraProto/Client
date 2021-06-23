using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public class AcceptTermsOfService : IMethod
    {
        public static int ConstructorId { get; } = -294455398;

        public System.Type Type { get; init; } = typeof(bool);
        public bool IsVector { get; init; } = false;
        public DataJSONBase Id { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Id);
        }

        public void Deserialize(Reader reader)
        {
            Id = reader.Read<DataJSONBase>();
        }
    }
}