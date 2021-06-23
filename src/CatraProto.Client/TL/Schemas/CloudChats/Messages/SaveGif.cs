using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class SaveGif : IMethod
    {
        public static int ConstructorId { get; } = 846868683;

        public System.Type Type { get; init; } = typeof(bool);
        public bool IsVector { get; init; } = false;
        public InputDocumentBase Id { get; set; }
        public bool Unsave { get; set; }

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
            writer.Write(Unsave);
        }

        public void Deserialize(Reader reader)
        {
            Id = reader.Read<InputDocumentBase>();
            Unsave = reader.Read<bool>();
        }
    }
}