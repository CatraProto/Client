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
    public partial class PeerDialogs : CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerDialogsBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 863093588; }

        [Newtonsoft.Json.JsonProperty("dialogs")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.DialogBase> Dialogs { get; set; }

        [Newtonsoft.Json.JsonProperty("messages")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> Messages { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        [Newtonsoft.Json.JsonProperty("state")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase State { get; set; }


#nullable enable
        public PeerDialogs(List<CatraProto.Client.TL.Schemas.CloudChats.DialogBase> dialogs, List<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> messages, List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users, CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase state)
        {
            Dialogs = dialogs;
            Messages = messages;
            Chats = chats;
            Users = users;
            State = state;
        }
#nullable disable
        internal PeerDialogs()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
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

            var checkstate = writer.WriteObject(State);
            if (checkstate.IsError)
            {
                return checkstate;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
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
            var trystate = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase>();
            if (trystate.IsError)
            {
                return ReadResult<IObject>.Move(trystate);
            }

            State = trystate.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.peerDialogs";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PeerDialogs();
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

            var cloneState = (CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase?)State.Clone();
            if (cloneState is null)
            {
                return null;
            }

            newClonedObject.State = cloneState;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PeerDialogs castedOther)
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

            if (State.Compare(castedOther.State))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}