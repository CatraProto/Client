using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateDraftMessage : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -299124375; }

        [Newtonsoft.Json.JsonProperty("peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("draft")]
        public CatraProto.Client.TL.Schemas.CloudChats.DraftMessageBase Draft { get; set; }


#nullable enable
        public UpdateDraftMessage(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.DraftMessageBase draft)
        {
            Peer = peer;
            Draft = draft;

        }
#nullable disable
        internal UpdateDraftMessage()
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
            var checkdraft = writer.WriteObject(Draft);
            if (checkdraft.IsError)
            {
                return checkdraft;
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
            var trydraft = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DraftMessageBase>();
            if (trydraft.IsError)
            {
                return ReadResult<IObject>.Move(trydraft);
            }
            Draft = trydraft.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updateDraftMessage";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}