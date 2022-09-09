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
    public partial class InputBotInlineResultPhoto : CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1462213465; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("type")] public string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("photo")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase Photo { get; set; }

        [Newtonsoft.Json.JsonProperty("send_message")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase SendMessage { get; set; }


#nullable enable
        public InputBotInlineResultPhoto(string id, string type, CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase photo, CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase sendMessage)
        {
            Id = id;
            Type = type;
            Photo = photo;
            SendMessage = sendMessage;
        }
#nullable disable
        internal InputBotInlineResultPhoto()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Id);

            writer.WriteString(Type);
            var checkphoto = writer.WriteObject(Photo);
            if (checkphoto.IsError)
            {
                return checkphoto;
            }

            var checksendMessage = writer.WriteObject(SendMessage);
            if (checksendMessage.IsError)
            {
                return checksendMessage;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadString();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            var trytype = reader.ReadString();
            if (trytype.IsError)
            {
                return ReadResult<IObject>.Move(trytype);
            }

            Type = trytype.Value;
            var tryphoto = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase>();
            if (tryphoto.IsError)
            {
                return ReadResult<IObject>.Move(tryphoto);
            }

            Photo = tryphoto.Value;
            var trysendMessage = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase>();
            if (trysendMessage.IsError)
            {
                return ReadResult<IObject>.Move(trysendMessage);
            }

            SendMessage = trysendMessage.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputBotInlineResultPhoto";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputBotInlineResultPhoto();
            newClonedObject.Id = Id;
            newClonedObject.Type = Type;
            var clonePhoto = (CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase?)Photo.Clone();
            if (clonePhoto is null)
            {
                return null;
            }

            newClonedObject.Photo = clonePhoto;
            var cloneSendMessage = (CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase?)SendMessage.Clone();
            if (cloneSendMessage is null)
            {
                return null;
            }

            newClonedObject.SendMessage = cloneSendMessage;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputBotInlineResultPhoto castedOther)
            {
                return true;
            }

            if (Id != castedOther.Id)
            {
                return true;
            }

            if (Type != castedOther.Type)
            {
                return true;
            }

            if (Photo.Compare(castedOther.Photo))
            {
                return true;
            }

            if (SendMessage.Compare(castedOther.SendMessage))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}