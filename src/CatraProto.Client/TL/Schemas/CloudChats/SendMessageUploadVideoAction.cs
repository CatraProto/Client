using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SendMessageUploadVideoAction : CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -378127636; }

        [Newtonsoft.Json.JsonProperty("progress")]
        public int Progress { get; set; }


#nullable enable
        public SendMessageUploadVideoAction(int progress)
        {
            Progress = progress;

        }
#nullable disable
        internal SendMessageUploadVideoAction()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Progress);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryprogress = reader.ReadInt32();
            if (tryprogress.IsError)
            {
                return ReadResult<IObject>.Move(tryprogress);
            }
            Progress = tryprogress.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "sendMessageUploadVideoAction";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SendMessageUploadVideoAction
            {
                Progress = Progress
            };
            return newClonedObject;

        }
#nullable disable
    }
}