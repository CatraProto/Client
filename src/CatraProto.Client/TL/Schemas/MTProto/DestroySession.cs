using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class DestroySession : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -414113498; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("session_id")]
        public long SessionId { get; set; }


#nullable enable
        public DestroySession(long sessionId)
        {
            SessionId = sessionId;

        }
#nullable disable

        internal DestroySession()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(SessionId);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trysessionId = reader.ReadInt64();
            if (trysessionId.IsError)
            {
                return ReadResult<IObject>.Move(trysessionId);
            }
            SessionId = trysessionId.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "destroy_session";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}