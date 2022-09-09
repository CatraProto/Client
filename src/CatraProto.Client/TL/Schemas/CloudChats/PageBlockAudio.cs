using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PageBlockAudio : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -2143067670; }

        [Newtonsoft.Json.JsonProperty("audio_id")]
        public long AudioId { get; set; }

        [Newtonsoft.Json.JsonProperty("caption")]
        public CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase Caption { get; set; }


#nullable enable
        public PageBlockAudio(long audioId, CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase caption)
        {
            AudioId = audioId;
            Caption = caption;
        }
#nullable disable
        internal PageBlockAudio()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(AudioId);
            var checkcaption = writer.WriteObject(Caption);
            if (checkcaption.IsError)
            {
                return checkcaption;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryaudioId = reader.ReadInt64();
            if (tryaudioId.IsError)
            {
                return ReadResult<IObject>.Move(tryaudioId);
            }

            AudioId = tryaudioId.Value;
            var trycaption = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase>();
            if (trycaption.IsError)
            {
                return ReadResult<IObject>.Move(trycaption);
            }

            Caption = trycaption.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "pageBlockAudio";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PageBlockAudio();
            newClonedObject.AudioId = AudioId;
            var cloneCaption = (CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase?)Caption.Clone();
            if (cloneCaption is null)
            {
                return null;
            }

            newClonedObject.Caption = cloneCaption;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PageBlockAudio castedOther)
            {
                return true;
            }

            if (AudioId != castedOther.AudioId)
            {
                return true;
            }

            if (Caption.Compare(castedOther.Caption))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}