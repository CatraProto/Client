using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class GetSavedRingtones : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -510647672; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("hash")]
        public long Hash { get; set; }


#nullable enable
        public GetSavedRingtones(long hash)
        {
            Hash = hash;

        }
#nullable disable

        internal GetSavedRingtones()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Hash);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryhash = reader.ReadInt64();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }
            Hash = tryhash.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.getSavedRingtones";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetSavedRingtones
            {
                Hash = Hash
            };
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not GetSavedRingtones castedOther)
            {
                return true;
            }
            if (Hash != castedOther.Hash)
            {
                return true;
            }
            return false;

        }
#nullable disable
    }
}