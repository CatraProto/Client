using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class StatsAbsValueAndPrev : CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase
    {
        public static int StaticConstructorId
        {
            get => -884757282;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("current")]
        public sealed override double Current { get; set; }

        [Newtonsoft.Json.JsonProperty("previous")]
        public sealed override double Previous { get; set; }


    #nullable enable
        public StatsAbsValueAndPrev(double current, double previous)
        {
            Current = current;
            Previous = previous;
        }
    #nullable disable
        internal StatsAbsValueAndPrev()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Current);
            writer.Write(Previous);
        }

        public override void Deserialize(Reader reader)
        {
            Current = reader.Read<double>();
            Previous = reader.Read<double>();
        }

        public override string ToString()
        {
            return "statsAbsValueAndPrev";
        }
    }
}