using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class NotifyPeer : CatraProto.Client.TL.Schemas.CloudChats.NotifyPeerBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1613493288; }

        [Newtonsoft.Json.JsonProperty("peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }


#nullable enable
        public NotifyPeer(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer)
        {
            Peer = peer;

        }
#nullable disable
        internal NotifyPeer()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }
            Peer = trypeer.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "notifyPeer";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new NotifyPeer();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }
            newClonedObject.Peer = clonePeer;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not NotifyPeer castedOther)
            {
                return true;
            }
            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}