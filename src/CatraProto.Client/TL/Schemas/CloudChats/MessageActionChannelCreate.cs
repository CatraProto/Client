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
    public partial class MessageActionChannelCreate : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1781355374; }

        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }


#nullable enable
        public MessageActionChannelCreate(string title)
        {
            Title = title;
        }
#nullable disable
        internal MessageActionChannelCreate()
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
            return "messageActionChannelCreate";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageActionChannelCreate();
            newClonedObject.Title = Title;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageActionChannelCreate castedOther)
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