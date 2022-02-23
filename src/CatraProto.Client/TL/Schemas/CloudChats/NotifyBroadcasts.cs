using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class NotifyBroadcasts : CatraProto.Client.TL.Schemas.CloudChats.NotifyPeerBase
    {
        public static int StaticConstructorId
        {
            get => -703403793;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public NotifyBroadcasts()
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
            return "notifyBroadcasts";
        }
    }
}