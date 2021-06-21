using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SendMessageUploadRoundAction : SendMessageActionBase
    {
        public static int ConstructorId { get; } = 608050278;
        public int Progress { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Progress);
        }

        public override void Deserialize(Reader reader)
        {
            Progress = reader.Read<int>();
        }
    }
}