using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class StatsPercentValue : CatraProto.Client.TL.Schemas.CloudChats.StatsPercentValueBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -875679776; }

        [Newtonsoft.Json.JsonProperty("part")]
        public sealed override double Part { get; set; }

        [Newtonsoft.Json.JsonProperty("total")]
        public sealed override double Total { get; set; }


#nullable enable
        public StatsPercentValue(double part, double total)
        {
            Part = part;
            Total = total;

        }
#nullable disable
        internal StatsPercentValue()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteDouble(Part);

            writer.WriteDouble(Total);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypart = reader.ReadDouble();
            if (trypart.IsError)
            {
                return ReadResult<IObject>.Move(trypart);
            }
            Part = trypart.Value;
            var trytotal = reader.ReadDouble();
            if (trytotal.IsError)
            {
                return ReadResult<IObject>.Move(trytotal);
            }
            Total = trytotal.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "statsPercentValue";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}