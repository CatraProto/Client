using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class InviteText : InviteTextBase
    {
        public static int StaticConstructorId
        {
            get => 415997816;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("message")] public override string Message { get; set; }


        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Message);
        }

        public override void Deserialize(Reader reader)
        {
            Message = reader.Read<string>();
        }

        public override string ToString()
        {
            return "help.inviteText";
        }
    }
}