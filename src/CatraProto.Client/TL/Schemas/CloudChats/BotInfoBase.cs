using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class BotInfoBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("user_id")]
        public abstract long? UserId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("description")]
        public abstract string Description { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("description_photo")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.PhotoBase DescriptionPhoto { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("description_document")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.DocumentBase DescriptionDocument { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("commands")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase> Commands { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("menu_button")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonBase MenuButton { get; set; }

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