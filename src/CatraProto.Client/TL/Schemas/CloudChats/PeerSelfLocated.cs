using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PeerSelfLocated : CatraProto.Client.TL.Schemas.CloudChats.PeerLocatedBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -118740917; }

        [Newtonsoft.Json.JsonProperty("expires")]
        public sealed override int Expires { get; set; }


#nullable enable
        public PeerSelfLocated(int expires)
        {
            Expires = expires;
        }
#nullable disable
        internal PeerSelfLocated()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Expires);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryexpires = reader.ReadInt32();
            if (tryexpires.IsError)
            {
                return ReadResult<IObject>.Move(tryexpires);
            }

            Expires = tryexpires.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "peerSelfLocated";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PeerSelfLocated();
            newClonedObject.Expires = Expires;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PeerSelfLocated castedOther)
            {
                return true;
            }

            if (Expires != castedOther.Expires)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}