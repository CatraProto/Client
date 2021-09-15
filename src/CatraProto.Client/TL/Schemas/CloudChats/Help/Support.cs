using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class Support : SupportBase
    {
        public static int StaticConstructorId
        {
            get => 398898678;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("phone_number")] public override string PhoneNumber { get; set; }

        [JsonProperty("user")] public override UserBase User { get; set; }


        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(PhoneNumber);
            writer.Write(User);
        }

        public override void Deserialize(Reader reader)
        {
            PhoneNumber = reader.Read<string>();
            User = reader.Read<UserBase>();
        }

        public override string ToString()
        {
            return "help.support";
        }
    }
}