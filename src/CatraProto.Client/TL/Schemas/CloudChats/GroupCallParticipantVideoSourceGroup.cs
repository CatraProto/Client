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
    public partial class GroupCallParticipantVideoSourceGroup : CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantVideoSourceGroupBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -592373577; }

        [Newtonsoft.Json.JsonProperty("semantics")]
        public sealed override string Semantics { get; set; }

        [Newtonsoft.Json.JsonProperty("sources")]
        public sealed override List<int> Sources { get; set; }


#nullable enable
        public GroupCallParticipantVideoSourceGroup(string semantics, List<int> sources)
        {
            Semantics = semantics;
            Sources = sources;
        }
#nullable disable
        internal GroupCallParticipantVideoSourceGroup()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Semantics);

            writer.WriteVector(Sources, false);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trysemantics = reader.ReadString();
            if (trysemantics.IsError)
            {
                return ReadResult<IObject>.Move(trysemantics);
            }

            Semantics = trysemantics.Value;
            var trysources = reader.ReadVector<int>(ParserTypes.Int);
            if (trysources.IsError)
            {
                return ReadResult<IObject>.Move(trysources);
            }

            Sources = trysources.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "groupCallParticipantVideoSourceGroup";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new GroupCallParticipantVideoSourceGroup();
            newClonedObject.Semantics = Semantics;
            newClonedObject.Sources = new List<int>();
            foreach (var sources in Sources)
            {
                newClonedObject.Sources.Add(sources);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not GroupCallParticipantVideoSourceGroup castedOther)
            {
                return true;
            }

            if (Semantics != castedOther.Semantics)
            {
                return true;
            }

            var sourcessize = castedOther.Sources.Count;
            if (sourcessize != Sources.Count)
            {
                return true;
            }

            for (var i = 0; i < sourcessize; i++)
            {
                if (castedOther.Sources[i] != Sources[i])
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}