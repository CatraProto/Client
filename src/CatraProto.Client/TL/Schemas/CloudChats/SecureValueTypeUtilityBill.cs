using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SecureValueTypeUtilityBill : CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase
    {
        public static int StaticConstructorId
        {
            get => -63531698;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public SecureValueTypeUtilityBill()
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
            return "secureValueTypeUtilityBill";
        }
    }
}