#nullable disable
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

namespace CatraProto.Client.TL.Schemas.FileContexts
{
    public partial class ContextFromPeerFull : CatraProto.Client.TL.Schemas.FileContexts.ContextBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1958493133; }

        [Newtonsoft.Json.JsonProperty("peer")] public long Peer { get; set; }


#nullable enable
        public ContextFromPeerFull(long peer)
        {
            Peer = peer;
        }
#nullable disable
        internal ContextFromPeerFull()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Peer);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeer = reader.ReadInt64();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "contextFromPeerFull";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ContextFromPeerFull();
            newClonedObject.Peer = Peer;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ContextFromPeerFull castedOther)
            {
                return true;
            }

            if (Peer != castedOther.Peer)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}