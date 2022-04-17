using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class DestroySessionOk : CatraProto.Client.TL.Schemas.MTProto.DestroySessionResBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -501201412; }

        [Newtonsoft.Json.JsonProperty("session_id")]
        public sealed override long SessionId { get; set; }


#nullable enable
        public DestroySessionOk(long sessionId)
        {
            SessionId = sessionId;

        }
#nullable disable
        internal DestroySessionOk()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(SessionId);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
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
            return "destroy_session_ok";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}