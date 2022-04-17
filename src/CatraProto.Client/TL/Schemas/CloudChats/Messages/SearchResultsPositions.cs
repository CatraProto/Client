using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class SearchResultsPositions : CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchResultsPositionsBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1404185519; }

        [Newtonsoft.Json.JsonProperty("count")]
        public sealed override int Count { get; set; }

        [Newtonsoft.Json.JsonProperty("positions")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.SearchResultsPositionBase> Positions { get; set; }


#nullable enable
        public SearchResultsPositions(int count, List<CatraProto.Client.TL.Schemas.CloudChats.SearchResultsPositionBase> positions)
        {
            Count = count;
            Positions = positions;

        }
#nullable disable
        internal SearchResultsPositions()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Count);
            var checkpositions = writer.WriteVector(Positions, false);
            if (checkpositions.IsError)
            {
                return checkpositions;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycount = reader.ReadInt32();
            if (trycount.IsError)
            {
                return ReadResult<IObject>.Move(trycount);
            }
            Count = trycount.Value;
            var trypositions = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SearchResultsPositionBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trypositions.IsError)
            {
                return ReadResult<IObject>.Move(trypositions);
            }
            Positions = trypositions.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.searchResultsPositions";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}