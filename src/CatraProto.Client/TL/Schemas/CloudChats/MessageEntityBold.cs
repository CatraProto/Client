using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageEntityBold : CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1117713463; }

        [Newtonsoft.Json.JsonProperty("offset")]
        public sealed override int Offset { get; set; }

        [Newtonsoft.Json.JsonProperty("length")]
        public sealed override int Length { get; set; }


#nullable enable
        public MessageEntityBold(int offset, int length)
        {
            Offset = offset;
            Length = length;

        }
#nullable disable
        internal MessageEntityBold()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Offset);
            writer.WriteInt32(Length);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryoffset = reader.ReadInt32();
            if (tryoffset.IsError)
            {
                return ReadResult<IObject>.Move(tryoffset);
            }
            Offset = tryoffset.Value;
            var trylength = reader.ReadInt32();
            if (trylength.IsError)
            {
                return ReadResult<IObject>.Move(trylength);
            }
            Length = trylength.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messageEntityBold";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageEntityBold
            {
                Offset = Offset,
                Length = Length
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageEntityBold castedOther)
            {
                return true;
            }
            if (Offset != castedOther.Offset)
            {
                return true;
            }
            if (Length != castedOther.Length)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}