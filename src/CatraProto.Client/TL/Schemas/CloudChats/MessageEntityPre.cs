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
    public partial class MessageEntityPre : CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1938967520; }

        [Newtonsoft.Json.JsonProperty("offset")]
        public sealed override int Offset { get; set; }

        [Newtonsoft.Json.JsonProperty("length")]
        public sealed override int Length { get; set; }

        [Newtonsoft.Json.JsonProperty("language")]
        public string Language { get; set; }


#nullable enable
        public MessageEntityPre(int offset, int length, string language)
        {
            Offset = offset;
            Length = length;
            Language = language;
        }
#nullable disable
        internal MessageEntityPre()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Offset);
            writer.WriteInt32(Length);

            writer.WriteString(Language);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryoffset = reader.ReadInt32();
            if (tryoffset.IsError)
            {
                return ReadResult<IObject>.Move(tryoffset);
            }

            Offset = tryoffset.Value;
            var trylength = reader.ReadInt32();
            if (trylength.IsError)
            {
                return ReadResult<IObject>.Move(trylength);
            }

            Length = trylength.Value;
            var trylanguage = reader.ReadString();
            if (trylanguage.IsError)
            {
                return ReadResult<IObject>.Move(trylanguage);
            }

            Language = trylanguage.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messageEntityPre";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageEntityPre();
            newClonedObject.Offset = Offset;
            newClonedObject.Length = Length;
            newClonedObject.Language = Language;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageEntityPre castedOther)
            {
                return true;
            }

            if (Offset != castedOther.Offset)
            {
                return true;
            }

            if (Length != castedOther.Length)
            {
                return true;
            }

            if (Language != castedOther.Language)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}