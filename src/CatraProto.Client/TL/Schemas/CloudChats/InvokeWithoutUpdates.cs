using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class InvokeWithoutUpdates : IMethod
    {
        public static int ConstructorId { get; } = -1080796745;

        public System.Type Type { get; init; } = typeof(IObject);
        public bool IsVector { get; init; } = false;
        public IObject Query { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Query);
        }

        public void Deserialize(Reader reader)
        {
            Query = reader.Read<IObject>();
        }
    }
}