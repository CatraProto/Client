using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class AttachMenuBotBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("inactive")]
        public abstract bool Inactive { get; set; }

        [Newtonsoft.Json.JsonProperty("bot_id")]
        public abstract long BotId { get; set; }

        [Newtonsoft.Json.JsonProperty("short_name")]
        public abstract string ShortName { get; set; }

        [Newtonsoft.Json.JsonProperty("icons")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotIconBase> Icons { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
        public abstract bool Compare(IObject other);
#nullable disable
    }
}
