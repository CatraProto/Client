using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
    public partial class ChannelDifferenceTooLong : CatraProto.Client.TL.Schemas.CloudChats.Updates.ChannelDifferenceBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Final = 1 << 0,
            Timeout = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1531132162; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("final")]
        public sealed override bool Final { get; set; }

        [Newtonsoft.Json.JsonProperty("timeout")]
        public sealed override int? Timeout { get; set; }

        [Newtonsoft.Json.JsonProperty("dialog")]
        public CatraProto.Client.TL.Schemas.CloudChats.DialogBase Dialog { get; set; }

        [Newtonsoft.Json.JsonProperty("messages")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> Messages { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public ChannelDifferenceTooLong(CatraProto.Client.TL.Schemas.CloudChats.DialogBase dialog, List<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> messages, List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Dialog = dialog;
            Messages = messages;
            Chats = chats;
            Users = users;
        }
#nullable disable
        internal ChannelDifferenceTooLong()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Final ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Timeout == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt32(Timeout.Value);
            }

            var checkdialog = writer.WriteObject(Dialog);
            if (checkdialog.IsError)
            {
                return checkdialog;
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
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            Final = FlagsHelper.IsFlagSet(Flags, 0);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trytimeout = reader.ReadInt32();
                if (trytimeout.IsError)
                {
                    return ReadResult<IObject>.Move(trytimeout);
                }

                Timeout = trytimeout.Value;
            }

            var trydialog = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DialogBase>();
            if (trydialog.IsError)
            {
                return ReadResult<IObject>.Move(trydialog);
            }

            Dialog = trydialog.Value;
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
            return "updates.channelDifferenceTooLong";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelDifferenceTooLong();
            newClonedObject.Flags = Flags;
            newClonedObject.Final = Final;
            newClonedObject.Timeout = Timeout;
            var cloneDialog = (CatraProto.Client.TL.Schemas.CloudChats.DialogBase?)Dialog.Clone();
            if (cloneDialog is null)
            {
                return null;
            }

            newClonedObject.Dialog = cloneDialog;
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
            if (other is not ChannelDifferenceTooLong castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Final != castedOther.Final)
            {
                return true;
            }

            if (Timeout != castedOther.Timeout)
            {
                return true;
            }

            if (Dialog.Compare(castedOther.Dialog))
            {
                return true;
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