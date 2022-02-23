using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class SentEncryptedFile : CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase
    {
        public static int StaticConstructorId
        {
            get => -1802240206;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("date")] public sealed override int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("file")] public CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase File { get; set; }


    #nullable enable
        public SentEncryptedFile(int date, CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase file)
        {
            Date = date;
            File = file;
        }
    #nullable disable
        internal SentEncryptedFile()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Date);
            writer.Write(File);
        }

        public override void Deserialize(Reader reader)
        {
            Date = reader.Read<int>();
            File = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase>();
        }

        public override string ToString()
        {
            return "messages.sentEncryptedFile";
        }
    }
}