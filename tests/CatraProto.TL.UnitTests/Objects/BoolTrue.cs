using CatraProto.TL.Interfaces;

namespace CatraProto.TL.UnitTests.Objects
{
    public partial class BoolTrue : IObject
    {
        public static int ConstructorId { get; } = -1720552011;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
        }

        public void Deserialize(Reader reader)
        {
        }
    }
}