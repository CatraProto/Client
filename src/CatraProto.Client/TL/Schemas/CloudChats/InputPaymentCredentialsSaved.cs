using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputPaymentCredentialsSaved : CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1056001329; }

        [Newtonsoft.Json.JsonProperty("id")]
        public string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("tmp_password")]
        public byte[] TmpPassword { get; set; }


#nullable enable
        public InputPaymentCredentialsSaved(string id, byte[] tmpPassword)
        {
            Id = id;
            TmpPassword = tmpPassword;

        }
#nullable disable
        internal InputPaymentCredentialsSaved()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Id);

            writer.WriteBytes(TmpPassword);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadString();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            var trytmpPassword = reader.ReadBytes();
            if (trytmpPassword.IsError)
            {
                return ReadResult<IObject>.Move(trytmpPassword);
            }
            TmpPassword = trytmpPassword.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "inputPaymentCredentialsSaved";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputPaymentCredentialsSaved
            {
                Id = Id,
                TmpPassword = TmpPassword
            };
            return newClonedObject;

        }
#nullable disable
    }
}