using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public class SaveCallDebug : IMethod
    {
        public static int ConstructorId { get; } = 662363518;

        public System.Type Type { get; init; } = typeof(bool);
        public bool IsVector { get; init; } = false;
        public InputPhoneCallBase Peer { get; set; }
        public DataJSONBase Debug { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Peer);
            writer.Write(Debug);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputPhoneCallBase>();
            Debug = reader.Read<DataJSONBase>();
        }
    }
}