using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public class GetAppChangelog : IMethod
    {
        public static int ConstructorId { get; } = -1877938321;

        public System.Type Type { get; init; } = typeof(UpdatesBase);
        public bool IsVector { get; init; } = false;
        public string PrevAppVersion { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(PrevAppVersion);
        }

        public void Deserialize(Reader reader)
        {
            PrevAppVersion = reader.Read<string>();
        }
    }
}