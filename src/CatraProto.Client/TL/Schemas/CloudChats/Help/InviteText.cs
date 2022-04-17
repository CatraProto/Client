using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class InviteText : CatraProto.Client.TL.Schemas.CloudChats.Help.InviteTextBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 415997816; }

        [Newtonsoft.Json.JsonProperty("message")]
        public sealed override string Message { get; set; }


#nullable enable
        public InviteText(string message)
        {
            Message = message;

        }
#nullable disable
        internal InviteText()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Message);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trymessage = reader.ReadString();
            if (trymessage.IsError)
            {
                return ReadResult<IObject>.Move(trymessage);
            }
            Message = trymessage.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "help.inviteText";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}