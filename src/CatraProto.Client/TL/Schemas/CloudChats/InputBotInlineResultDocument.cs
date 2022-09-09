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
    public partial class InputBotInlineResultDocument : CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Title = 1 << 1,
            Description = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -459324; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("type")] public string Type { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("description")]
        public string Description { get; set; }

        [Newtonsoft.Json.JsonProperty("document")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Document { get; set; }

        [Newtonsoft.Json.JsonProperty("send_message")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase SendMessage { get; set; }


#nullable enable
        public InputBotInlineResultDocument(string id, string type, CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase document, CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase sendMessage)
        {
            Id = id;
            Type = type;
            Document = document;
            SendMessage = sendMessage;
        }
#nullable disable
        internal InputBotInlineResultDocument()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = Description == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Id);

            writer.WriteString(Type);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteString(Title);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteString(Description);
            }

            var checkdocument = writer.WriteObject(Document);
            if (checkdocument.IsError)
            {
                return checkdocument;
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
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trytitle = reader.ReadString();
                if (trytitle.IsError)
                {
                    return ReadResult<IObject>.Move(trytitle);
                }

                Title = trytitle.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trydescription = reader.ReadString();
                if (trydescription.IsError)
                {
                    return ReadResult<IObject>.Move(trydescription);
                }

                Description = trydescription.Value;
            }

            var trydocument = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();
            if (trydocument.IsError)
            {
                return ReadResult<IObject>.Move(trydocument);
            }

            Document = trydocument.Value;
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
            return "inputBotInlineResultDocument";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputBotInlineResultDocument();
            newClonedObject.Flags = Flags;
            newClonedObject.Id = Id;
            newClonedObject.Type = Type;
            newClonedObject.Title = Title;
            newClonedObject.Description = Description;
            var cloneDocument = (CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase?)Document.Clone();
            if (cloneDocument is null)
            {
                return null;
            }

            newClonedObject.Document = cloneDocument;
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
            if (other is not InputBotInlineResultDocument castedOther)
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

            if (Title != castedOther.Title)
            {
                return true;
            }

            if (Description != castedOther.Description)
            {
                return true;
            }

            if (Document.Compare(castedOther.Document))
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