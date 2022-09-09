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
    public partial class ChatsSlice : CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1663561404; }

        [Newtonsoft.Json.JsonProperty("count")]
        public int Count { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> ChatsField { get; set; }


#nullable enable
        public ChatsSlice(int count, List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chatsField)
        {
            Count = count;
            ChatsField = chatsField;
        }
#nullable disable
        internal ChatsSlice()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Count);
            var checkchatsField = writer.WriteVector(ChatsField, false);
            if (checkchatsField.IsError)
            {
                return checkchatsField;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycount = reader.ReadInt32();
            if (trycount.IsError)
            {
                return ReadResult<IObject>.Move(trycount);
            }

            Count = trycount.Value;
            var trychatsField = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trychatsField.IsError)
            {
                return ReadResult<IObject>.Move(trychatsField);
            }

            ChatsField = trychatsField.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.chatsSlice";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChatsSlice();
            newClonedObject.Count = Count;
            newClonedObject.ChatsField = new List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
            foreach (var chatsField in ChatsField)
            {
                var clonechatsField = (CatraProto.Client.TL.Schemas.CloudChats.ChatBase?)chatsField.Clone();
                if (clonechatsField is null)
                {
                    return null;
                }

                newClonedObject.ChatsField.Add(clonechatsField);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChatsSlice castedOther)
            {
                return true;
            }

            if (Count != castedOther.Count)
            {
                return true;
            }

            var chatsFieldsize = castedOther.ChatsField.Count;
            if (chatsFieldsize != ChatsField.Count)
            {
                return true;
            }

            for (var i = 0; i < chatsFieldsize; i++)
            {
                if (castedOther.ChatsField[i].Compare(ChatsField[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}