using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetAttachedStickers : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -866424884; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("media")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputStickeredMediaBase Media { get; set; }


#nullable enable
        public GetAttachedStickers(CatraProto.Client.TL.Schemas.CloudChats.InputStickeredMediaBase media)
        {
            Media = media;
        }
#nullable disable

        internal GetAttachedStickers()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkmedia = writer.WriteObject(Media);
            if (checkmedia.IsError)
            {
                return checkmedia;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trymedia = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputStickeredMediaBase>();
            if (trymedia.IsError)
            {
                return ReadResult<IObject>.Move(trymedia);
            }

            Media = trymedia.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.getAttachedStickers";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetAttachedStickers();
            var cloneMedia = (CatraProto.Client.TL.Schemas.CloudChats.InputStickeredMediaBase?)Media.Clone();
            if (cloneMedia is null)
            {
                return null;
            }

            newClonedObject.Media = cloneMedia;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetAttachedStickers castedOther)
            {
                return true;
            }

            if (Media.Compare(castedOther.Media))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}