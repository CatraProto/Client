using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class NotifyBroadcasts : CatraProto.Client.TL.Schemas.CloudChats.NotifyPeerBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -703403793; }



        public NotifyBroadcasts()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "notifyBroadcasts";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new NotifyBroadcasts();
            return newClonedObject;

        }
#nullable disable
    }
}