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
    public partial class ChannelParticipantsSearch : CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantsFilterBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 106343499; }

        [Newtonsoft.Json.JsonProperty("q")] public string Q { get; set; }


#nullable enable
        public ChannelParticipantsSearch(string q)
        {
            Q = q;
        }
#nullable disable
        internal ChannelParticipantsSearch()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Q);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryq = reader.ReadString();
            if (tryq.IsError)
            {
                return ReadResult<IObject>.Move(tryq);
            }

            Q = tryq.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channelParticipantsSearch";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelParticipantsSearch();
            newClonedObject.Q = Q;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChannelParticipantsSearch castedOther)
            {
                return true;
            }

            if (Q != castedOther.Q)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}