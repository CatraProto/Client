using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class BotCommandBase : IObject
    {

[JsonPropertyName("command")]
		public abstract string Command { get; set; }

[JsonPropertyName("description")]
		public abstract string Description { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
