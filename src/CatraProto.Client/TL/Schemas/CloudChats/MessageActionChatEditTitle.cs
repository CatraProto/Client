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
    public partial class MessageActionChatEditTitle : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1247687078; }

        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }


#nullable enable
        public MessageActionChatEditTitle(string title)
        {
            Title = title;
        }
#nullable disable
        internal MessageActionChatEditTitle()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Title);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytitle = reader.ReadString();
            if (trytitle.IsError)
            {
                return ReadResult<IObject>.Move(trytitle);
            }

            Title = trytitle.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messageActionChatEditTitle";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageActionChatEditTitle();
            newClonedObject.Title = Title;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageActionChatEditTitle castedOther)
            {
                return true;
            }

            if (Title != castedOther.Title)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}