using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PhoneCallDiscardReasonBusy : CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonBase
    {
        public static int StaticConstructorId
        {
            get => -84416311;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public PhoneCallDiscardReasonBusy()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
        }

        public override void Deserialize(Reader reader)
        {
        }

        public override string ToString()
        {
            return "phoneCallDiscardReasonBusy";
        }
    }
}