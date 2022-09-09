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
    public partial class MessageActionChatEditPhoto : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 2144015272; }

        [Newtonsoft.Json.JsonProperty("photo")]
        public CatraProto.Client.TL.Schemas.CloudChats.PhotoBase Photo { get; set; }


#nullable enable
        public MessageActionChatEditPhoto(CatraProto.Client.TL.Schemas.CloudChats.PhotoBase photo)
        {
            Photo = photo;
        }
#nullable disable
        internal MessageActionChatEditPhoto()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkphoto = writer.WriteObject(Photo);
            if (checkphoto.IsError)
            {
                return checkphoto;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryphoto = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
            if (tryphoto.IsError)
            {
                return ReadResult<IObject>.Move(tryphoto);
            }

            Photo = tryphoto.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messageActionChatEditPhoto";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageActionChatEditPhoto();
            var clonePhoto = (CatraProto.Client.TL.Schemas.CloudChats.PhotoBase?)Photo.Clone();
            if (clonePhoto is null)
            {
                return null;
            }

            newClonedObject.Photo = clonePhoto;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageActionChatEditPhoto castedOther)
            {
                return true;
            }

            if (Photo.Compare(castedOther.Photo))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}