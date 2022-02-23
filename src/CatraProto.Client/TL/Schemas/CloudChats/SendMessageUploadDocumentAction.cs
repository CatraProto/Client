using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SendMessageUploadDocumentAction : CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase
    {
        public static int StaticConstructorId
        {
            get => -1441998364;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("progress")]
        public int Progress { get; set; }


    #nullable enable
        public SendMessageUploadDocumentAction(int progress)
        {
            Progress = progress;
        }
    #nullable disable
        internal SendMessageUploadDocumentAction()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Progress);
        }

        public override void Deserialize(Reader reader)
        {
            Progress = reader.Read<int>();
        }

        public override string ToString()
        {
            return "sendMessageUploadDocumentAction";
        }
    }
}