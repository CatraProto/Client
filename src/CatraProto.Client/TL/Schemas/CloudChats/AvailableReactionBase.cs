using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class AvailableReactionBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("inactive")]
        public abstract bool Inactive { get; set; }

        [Newtonsoft.Json.JsonProperty("premium")]
        public abstract bool Premium { get; set; }

        [Newtonsoft.Json.JsonProperty("reaction")]
        public abstract string Reaction { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public abstract string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("static_icon")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.DocumentBase StaticIcon { get; set; }

        [Newtonsoft.Json.JsonProperty("appear_animation")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.DocumentBase AppearAnimation { get; set; }

        [Newtonsoft.Json.JsonProperty("select_animation")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.DocumentBase SelectAnimation { get; set; }

        [Newtonsoft.Json.JsonProperty("activate_animation")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.DocumentBase ActivateAnimation { get; set; }

        [Newtonsoft.Json.JsonProperty("effect_animation")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.DocumentBase EffectAnimation { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("around_animation")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.DocumentBase AroundAnimation { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("center_icon")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.DocumentBase CenterIcon { get; set; }

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