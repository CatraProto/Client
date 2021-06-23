using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public class DismissSuggestion : IMethod
    {
        public static int ConstructorId { get; } = 125807007;

        public System.Type Type { get; init; } = typeof(bool);
        public bool IsVector { get; init; } = false;
        public string Suggestion { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Suggestion);
        }

        public void Deserialize(Reader reader)
        {
            Suggestion = reader.Read<string>();
        }
    }
}