using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputNotifyBroadcasts : CatraProto.Client.TL.Schemas.CloudChats.InputNotifyPeerBase
    {
        public static int StaticConstructorId
        {
            get => -1311015810;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public InputNotifyBroadcasts()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
        }

        public override void Deserialize(Reader reader)
        {
        }

        public override string ToString()
        {
            return "inputNotifyBroadcasts";
        }
    }
}