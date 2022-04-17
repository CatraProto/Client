using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ReceivedNotifyMessage : CatraProto.Client.TL.Schemas.CloudChats.ReceivedNotifyMessageBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1551583367; }

        [Newtonsoft.Json.JsonProperty("id")]
        public sealed override int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("flags")]
        public sealed override int Flags { get; set; }


#nullable enable
        public ReceivedNotifyMessage(int id, int flags)
        {
            Id = id;
            Flags = flags;

        }
#nullable disable
        internal ReceivedNotifyMessage()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Id);
            writer.WriteInt32(Flags);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadInt32();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "receivedNotifyMessage";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}