using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputStickerSetItemBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("document")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Document { get; set; }

        [Newtonsoft.Json.JsonProperty("emoji")]
        public abstract string Emoji { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("mask_coords")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.MaskCoordsBase MaskCoords { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
#nullable disable
    }
}
