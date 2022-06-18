using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class SentEncryptedMessage : CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1443858741; }

        [Newtonsoft.Json.JsonProperty("date")]
        public sealed override int Date { get; set; }


#nullable enable
        public SentEncryptedMessage(int date)
        {
            Date = date;

        }
#nullable disable
        internal SentEncryptedMessage()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Date);

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
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.sentEncryptedMessage";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SentEncryptedMessage
            {
                Date = Date
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not SentEncryptedMessage castedOther)
            {
                return true;
            }
            if (Date != castedOther.Date)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}