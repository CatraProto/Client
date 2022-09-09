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
    public partial class EditChatPhoto : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 903730804; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public long ChatId { get; set; }

        [Newtonsoft.Json.JsonProperty("photo")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputChatPhotoBase Photo { get; set; }


#nullable enable
        public EditChatPhoto(long chatId, CatraProto.Client.TL.Schemas.CloudChats.InputChatPhotoBase photo)
        {
            ChatId = chatId;
            Photo = photo;
        }
#nullable disable

        internal EditChatPhoto()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(ChatId);
            var checkphoto = writer.WriteObject(Photo);
            if (checkphoto.IsError)
            {
                return checkphoto;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trychatId = reader.ReadInt64();
            if (trychatId.IsError)
            {
                return ReadResult<IObject>.Move(trychatId);
            }

            ChatId = trychatId.Value;
            var tryphoto = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputChatPhotoBase>();
            if (tryphoto.IsError)
            {
                return ReadResult<IObject>.Move(tryphoto);
            }

            Photo = tryphoto.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.editChatPhoto";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new EditChatPhoto();
            newClonedObject.ChatId = ChatId;
            var clonePhoto = (CatraProto.Client.TL.Schemas.CloudChats.InputChatPhotoBase?)Photo.Clone();
            if (clonePhoto is null)
            {
                return null;
            }

            newClonedObject.Photo = clonePhoto;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not EditChatPhoto castedOther)
            {
                return true;
            }

            if (ChatId != castedOther.ChatId)
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