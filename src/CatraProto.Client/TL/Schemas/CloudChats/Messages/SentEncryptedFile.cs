using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class SentEncryptedFile : CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1802240206; }

        [Newtonsoft.Json.JsonProperty("date")]
        public sealed override int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("file")]
        public CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase File { get; set; }


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

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Date);
            var checkfile = writer.WriteObject(File);
            if (checkfile.IsError)
            {
                return checkfile;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }
            Date = trydate.Value;
            var tryfile = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase>();
            if (tryfile.IsError)
            {
                return ReadResult<IObject>.Move(tryfile);
            }
            File = tryfile.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.sentEncryptedFile";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}