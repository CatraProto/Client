using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PeerBlocked : CatraProto.Client.TL.Schemas.CloudChats.PeerBlockedBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -386039788; }

        [Newtonsoft.Json.JsonProperty("peer_id")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerBase PeerId { get; set; }

        [Newtonsoft.Json.JsonProperty("date")]
        public sealed override int Date { get; set; }


#nullable enable
        public PeerBlocked(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peerId, int date)
        {
            PeerId = peerId;
            Date = date;

        }
#nullable disable
        internal PeerBlocked()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpeerId = writer.WriteObject(PeerId);
            if (checkpeerId.IsError)
            {
                return checkpeerId;
            }
            writer.WriteInt32(Date);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeerId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            if (trypeerId.IsError)
            {
                return ReadResult<IObject>.Move(trypeerId);
            }
            PeerId = trypeerId.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }
            Date = trydate.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "peerBlocked";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}