using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SecureValueErrorFile : CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 2054162547; }

        [Newtonsoft.Json.JsonProperty("type")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase Type { get; set; }

        [Newtonsoft.Json.JsonProperty("file_hash")]
        public byte[] FileHash { get; set; }

        [Newtonsoft.Json.JsonProperty("text")]
        public sealed override string Text { get; set; }


#nullable enable
        public SecureValueErrorFile(CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase type, byte[] fileHash, string text)
        {
            Type = type;
            FileHash = fileHash;
            Text = text;

        }
#nullable disable
        internal SecureValueErrorFile()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checktype = writer.WriteObject(Type);
            if (checktype.IsError)
            {
                return checktype;
            }

            writer.WriteBytes(FileHash);

            writer.WriteString(Text);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytype = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase>();
            if (trytype.IsError)
            {
                return ReadResult<IObject>.Move(trytype);
            }
            Type = trytype.Value;
            var tryfileHash = reader.ReadBytes();
            if (tryfileHash.IsError)
            {
                return ReadResult<IObject>.Move(tryfileHash);
            }
            FileHash = tryfileHash.Value;
            var trytext = reader.ReadString();
            if (trytext.IsError)
            {
                return ReadResult<IObject>.Move(trytext);
            }
            Text = trytext.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "secureValueErrorFile";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SecureValueErrorFile();
            var cloneType = (CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase?)Type.Clone();
            if (cloneType is null)
            {
                return null;
            }
            newClonedObject.Type = cloneType;
            newClonedObject.FileHash = FileHash;
            newClonedObject.Text = Text;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not SecureValueErrorFile castedOther)
            {
                return true;
            }
            if (Type.Compare(castedOther.Type))
            {
                return true;
            }
            if (FileHash != castedOther.FileHash)
            {
                return true;
            }
            if (Text != castedOther.Text)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}