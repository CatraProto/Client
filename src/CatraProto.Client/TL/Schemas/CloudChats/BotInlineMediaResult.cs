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
    public partial class BotInlineMediaResult : CatraProto.Client.TL.Schemas.CloudChats.BotInlineResultBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Photo = 1 << 0,
            Document = 1 << 1,
            Title = 1 << 2,
            Description = 1 << 3
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 400266251; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("type")] public sealed override string Type { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("photo")]
        public CatraProto.Client.TL.Schemas.CloudChats.PhotoBase Photo { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("document")]
        public CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Document { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("description")]
        public string Description { get; set; }

        [Newtonsoft.Json.JsonProperty("send_message")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageBase SendMessage { get; set; }


#nullable enable
        public BotInlineMediaResult(string id, string type, CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageBase sendMessage)
        {
            Id = id;
            Type = type;
            SendMessage = sendMessage;
        }
#nullable disable
        internal BotInlineMediaResult()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Photo == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Document == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = Description == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Id);

            writer.WriteString(Type);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkphoto = writer.WriteObject(Photo);
                if (checkphoto.IsError)
                {
                    return checkphoto;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checkdocument = writer.WriteObject(Document);
                if (checkdocument.IsError)
                {
                    return checkdocument;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteString(Title);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.WriteString(Description);
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
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
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
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryphoto = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
                if (tryphoto.IsError)
                {
                    return ReadResult<IObject>.Move(tryphoto);
                }

                Photo = tryphoto.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trydocument = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
                if (trydocument.IsError)
                {
                    return ReadResult<IObject>.Move(trydocument);
                }

                Document = trydocument.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trytitle = reader.ReadString();
                if (trytitle.IsError)
                {
                    return ReadResult<IObject>.Move(trytitle);
                }

                Title = trytitle.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var trydescription = reader.ReadString();
                if (trydescription.IsError)
                {
                    return ReadResult<IObject>.Move(trydescription);
                }

                Description = trydescription.Value;
            }

            var trysendMessage = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageBase>();
            if (trysendMessage.IsError)
            {
                return ReadResult<IObject>.Move(trysendMessage);
            }

            SendMessage = trysendMessage.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "botInlineMediaResult";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new BotInlineMediaResult();
            newClonedObject.Flags = Flags;
            newClonedObject.Id = Id;
            newClonedObject.Type = Type;
            if (Photo is not null)
            {
                var clonePhoto = (CatraProto.Client.TL.Schemas.CloudChats.PhotoBase?)Photo.Clone();
                if (clonePhoto is null)
                {
                    return null;
                }

                newClonedObject.Photo = clonePhoto;
            }

            if (Document is not null)
            {
                var cloneDocument = (CatraProto.Client.TL.Schemas.CloudChats.DocumentBase?)Document.Clone();
                if (cloneDocument is null)
                {
                    return null;
                }

                newClonedObject.Document = cloneDocument;
            }

            newClonedObject.Title = Title;
            newClonedObject.Description = Description;
            var cloneSendMessage = (CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageBase?)SendMessage.Clone();
            if (cloneSendMessage is null)
            {
                return null;
            }

            newClonedObject.SendMessage = cloneSendMessage;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not BotInlineMediaResult castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
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

            if (Photo is null && castedOther.Photo is not null || Photo is not null && castedOther.Photo is null)
            {
                return true;
            }

            if (Photo is not null && castedOther.Photo is not null && Photo.Compare(castedOther.Photo))
            {
                return true;
            }

            if (Document is null && castedOther.Document is not null || Document is not null && castedOther.Document is null)
            {
                return true;
            }

            if (Document is not null && castedOther.Document is not null && Document.Compare(castedOther.Document))
            {
                return true;
            }

            if (Title != castedOther.Title)
            {
                return true;
            }

            if (Description != castedOther.Description)
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