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
    public partial class DialogsSlice : CatraProto.Client.TL.Schemas.CloudChats.Messages.DialogsBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1910543603; }

        [Newtonsoft.Json.JsonProperty("count")]
        public int Count { get; set; }

        [Newtonsoft.Json.JsonProperty("dialogs")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.DialogBase> Dialogs { get; set; }

        [Newtonsoft.Json.JsonProperty("messages")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> Messages { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public DialogsSlice(int count, List<CatraProto.Client.TL.Schemas.CloudChats.DialogBase> dialogs, List<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> messages, List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Count = count;
            Dialogs = dialogs;
            Messages = messages;
            Chats = chats;
            Users = users;
        }
#nullable disable
        internal DialogsSlice()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Count);
            var checkdialogs = writer.WriteVector(Dialogs, false);
            if (checkdialogs.IsError)
            {
                return checkdialogs;
            }

            var checkmessages = writer.WriteVector(Messages, false);
            if (checkmessages.IsError)
            {
                return checkmessages;
            }

            var checkchats = writer.WriteVector(Chats, false);
            if (checkchats.IsError)
            {
                return checkchats;
            }

            var checkusers = writer.WriteVector(Users, false);
            if (checkusers.IsError)
            {
                return checkusers;
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
            var trydialogs = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DialogBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trydialogs.IsError)
            {
                return ReadResult<IObject>.Move(trydialogs);
            }

            Dialogs = trydialogs.Value;
            var trymessages = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trymessages.IsError)
            {
                return ReadResult<IObject>.Move(trymessages);
            }

            Messages = trymessages.Value;
            var trychats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trychats.IsError)
            {
                return ReadResult<IObject>.Move(trychats);
            }

            Chats = trychats.Value;
            var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryusers.IsError)
            {
                return ReadResult<IObject>.Move(tryusers);
            }

            Users = tryusers.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.dialogsSlice";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new DialogsSlice();
            newClonedObject.Count = Count;
            newClonedObject.Dialogs = new List<CatraProto.Client.TL.Schemas.CloudChats.DialogBase>();
            foreach (var dialogs in Dialogs)
            {
                var clonedialogs = (CatraProto.Client.TL.Schemas.CloudChats.DialogBase?)dialogs.Clone();
                if (clonedialogs is null)
                {
                    return null;
                }

                newClonedObject.Dialogs.Add(clonedialogs);
            }

            newClonedObject.Messages = new List<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
            foreach (var messages in Messages)
            {
                var clonemessages = (CatraProto.Client.TL.Schemas.CloudChats.MessageBase?)messages.Clone();
                if (clonemessages is null)
                {
                    return null;
                }

                newClonedObject.Messages.Add(clonemessages);
            }

            newClonedObject.Chats = new List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
            foreach (var chats in Chats)
            {
                var clonechats = (CatraProto.Client.TL.Schemas.CloudChats.ChatBase?)chats.Clone();
                if (clonechats is null)
                {
                    return null;
                }

                newClonedObject.Chats.Add(clonechats);
            }

            newClonedObject.Users = new List<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
            foreach (var users in Users)
            {
                var cloneusers = (CatraProto.Client.TL.Schemas.CloudChats.UserBase?)users.Clone();
                if (cloneusers is null)
                {
                    return null;
                }

                newClonedObject.Users.Add(cloneusers);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not DialogsSlice castedOther)
            {
                return true;
            }

            if (Count != castedOther.Count)
            {
                return true;
            }

            var dialogssize = castedOther.Dialogs.Count;
            if (dialogssize != Dialogs.Count)
            {
                return true;
            }

            for (var i = 0; i < dialogssize; i++)
            {
                if (castedOther.Dialogs[i].Compare(Dialogs[i]))
                {
                    return true;
                }
            }

            var messagessize = castedOther.Messages.Count;
            if (messagessize != Messages.Count)
            {
                return true;
            }

            for (var i = 0; i < messagessize; i++)
            {
                if (castedOther.Messages[i].Compare(Messages[i]))
                {
                    return true;
                }
            }

            var chatssize = castedOther.Chats.Count;
            if (chatssize != Chats.Count)
            {
                return true;
            }

            for (var i = 0; i < chatssize; i++)
            {
                if (castedOther.Chats[i].Compare(Chats[i]))
                {
                    return true;
                }
            }

            var userssize = castedOther.Users.Count;
            if (userssize != Users.Count)
            {
                return true;
            }

            for (var i = 0; i < userssize; i++)
            {
                if (castedOther.Users[i].Compare(Users[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}