using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class GetGroupParticipants : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -984033109; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("call")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

        [Newtonsoft.Json.JsonProperty("ids")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> Ids { get; set; }

        [Newtonsoft.Json.JsonProperty("sources")]
        public List<int> Sources { get; set; }

        [Newtonsoft.Json.JsonProperty("offset")]
        public string Offset { get; set; }

        [Newtonsoft.Json.JsonProperty("limit")]
        public int Limit { get; set; }


#nullable enable
        public GetGroupParticipants(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, List<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> ids, List<int> sources, string offset, int limit)
        {
            Call = call;
            Ids = ids;
            Sources = sources;
            Offset = offset;
            Limit = limit;

        }
#nullable disable

        internal GetGroupParticipants()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkcall = writer.WriteObject(Call);
            if (checkcall.IsError)
            {
                return checkcall;
            }
            var checkids = writer.WriteVector(Ids, false);
            if (checkids.IsError)
            {
                return checkids;
            }

            writer.WriteVector(Sources, false);

            writer.WriteString(Offset);
            writer.WriteInt32(Limit);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycall = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
            if (trycall.IsError)
            {
                return ReadResult<IObject>.Move(trycall);
            }
            Call = trycall.Value;
            var tryids = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryids.IsError)
            {
                return ReadResult<IObject>.Move(tryids);
            }
            Ids = tryids.Value;
            var trysources = reader.ReadVector<int>(ParserTypes.Int);
            if (trysources.IsError)
            {
                return ReadResult<IObject>.Move(trysources);
            }
            Sources = trysources.Value;
            var tryoffset = reader.ReadString();
            if (tryoffset.IsError)
            {
                return ReadResult<IObject>.Move(tryoffset);
            }
            Offset = tryoffset.Value;
            var trylimit = reader.ReadInt32();
            if (trylimit.IsError)
            {
                return ReadResult<IObject>.Move(trylimit);
            }
            Limit = trylimit.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "phone.getGroupParticipants";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetGroupParticipants();
            var cloneCall = (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase?)Call.Clone();
            if (cloneCall is null)
            {
                return null;
            }
            newClonedObject.Call = cloneCall;
            foreach (var ids in Ids)
            {
                var cloneids = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)ids.Clone();
                if (cloneids is null)
                {
                    return null;
                }
                newClonedObject.Ids.Add(cloneids);
            }
            foreach (var sources in Sources)
            {
                newClonedObject.Sources.Add(sources);
            }
            newClonedObject.Offset = Offset;
            newClonedObject.Limit = Limit;
            return newClonedObject;

        }
#nullable disable
    }
}