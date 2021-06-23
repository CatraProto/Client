using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public class GetDeepLinkInfo : IMethod
    {
        public static int ConstructorId { get; } = 1072547679;

        public System.Type Type { get; init; } = typeof(DeepLinkInfoBase);
        public bool IsVector { get; init; } = false;
        public string Path { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Path);
        }

        public void Deserialize(Reader reader)
        {
            Path = reader.Read<string>();
        }
    }
}