using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class FaveSticker : IMethod
    {
        public static int ConstructorId { get; } = -1174420133;

        public System.Type Type { get; init; } = typeof(bool);
        public bool IsVector { get; init; } = false;
        public InputDocumentBase Id { get; set; }
        public bool Unfave { get; set; }

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
            writer.Write(Unfave);
        }

        public void Deserialize(Reader reader)
        {
            Id = reader.Read<InputDocumentBase>();
            Unfave = reader.Read<bool>();
        }
    }
}