using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class BotInlineResultBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("id")]
        public abstract string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("type")]
        public abstract string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("send_message")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageBase SendMessage { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
#nullable disable
    }
}
