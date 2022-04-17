using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
    public partial class DifferenceTooLong : CatraProto.Client.TL.Schemas.CloudChats.Updates.DifferenceBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1258196845; }

        [Newtonsoft.Json.JsonProperty("pts")]
        public int Pts { get; set; }


#nullable enable
        public DifferenceTooLong(int pts)
        {
            Pts = pts;

        }
#nullable disable
        internal DifferenceTooLong()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Pts);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypts = reader.ReadInt32();
            if (trypts.IsError)
            {
                return ReadResult<IObject>.Move(trypts);
            }
            Pts = trypts.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updates.differenceTooLong";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}