using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class DialogsNotModified : DialogsBase
    {
        public static int StaticConstructorId
        {
            get => -253500010;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("count")] public int Count { get; set; }


        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Count);
        }

        public override void Deserialize(Reader reader)
        {
            Count = reader.Read<int>();
        }

        public override string ToString()
        {
            return "messages.dialogsNotModified";
        }
    }
}