#nullable disable
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

namespace CatraProto.Client.TL.Schemas.FileContexts
{
    public partial class ContextFromPeerPhotos : CatraProto.Client.TL.Schemas.FileContexts.ContextBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1774404363; }

        [Newtonsoft.Json.JsonProperty("peer")] public long Peer { get; set; }


#nullable enable
        public ContextFromPeerPhotos(long peer)
        {
            Peer = peer;
        }
#nullable disable
        internal ContextFromPeerPhotos()
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
            return "contextFromPeerPhotos";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ContextFromPeerPhotos();
            newClonedObject.Peer = Peer;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ContextFromPeerPhotos castedOther)
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