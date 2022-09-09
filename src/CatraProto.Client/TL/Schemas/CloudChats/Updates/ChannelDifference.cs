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
    public partial class ChannelDifference : CatraProto.Client.TL.Schemas.CloudChats.Updates.ChannelDifferenceBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Final = 1 << 0,
            Timeout = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 543450958; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("final")]
        public sealed override bool Final { get; set; }

        [Newtonsoft.Json.JsonProperty("pts")] public int Pts { get; set; }

        [Newtonsoft.Json.JsonProperty("timeout")]
        public sealed override int? Timeout { get; set; }

        [Newtonsoft.Json.JsonProperty("new_messages")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> NewMessages { get; set; }

        [Newtonsoft.Json.JsonProperty("other_updates")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase> OtherUpdates { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public ChannelDifference(int pts, List<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> newMessages, List<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase> otherUpdates, List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Pts = pts;
            NewMessages = newMessages;
            OtherUpdates = otherUpdates;
            Chats = chats;
            Users = users;
        }
#nullable disable
        internal ChannelDifference()
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
            writer.WriteInt32(Pts);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt32(Timeout.Value);
            }

            var checknewMessages = writer.WriteVector(NewMessages, false);
            if (checknewMessages.IsError)
            {
                return checknewMessages;
            }

            var checkotherUpdates = writer.WriteVector(OtherUpdates, false);
            if (checkotherUpdates.IsError)
            {
                return checkotherUpdates;
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
            var trypts = reader.ReadInt32();
            if (trypts.IsError)
            {
                return ReadResult<IObject>.Move(trypts);
            }

            Pts = trypts.Value;
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trytimeout = reader.ReadInt32();
                if (trytimeout.IsError)
                {
                    return ReadResult<IObject>.Move(trytimeout);
                }

                Timeout = trytimeout.Value;
            }

            var trynewMessages = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trynewMessages.IsError)
            {
                return ReadResult<IObject>.Move(trynewMessages);
            }

            NewMessages = trynewMessages.Value;
            var tryotherUpdates = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryotherUpdates.IsError)
            {
                return ReadResult<IObject>.Move(tryotherUpdates);
            }

            OtherUpdates = tryotherUpdates.Value;
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
            return "updates.channelDifference";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelDifference();
            newClonedObject.Flags = Flags;
            newClonedObject.Final = Final;
            newClonedObject.Pts = Pts;
            newClonedObject.Timeout = Timeout;
            newClonedObject.NewMessages = new List<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
            foreach (var newMessages in NewMessages)
            {
                var clonenewMessages = (CatraProto.Client.TL.Schemas.CloudChats.MessageBase?)newMessages.Clone();
                if (clonenewMessages is null)
                {
                    return null;
                }

                newClonedObject.NewMessages.Add(clonenewMessages);
            }

            newClonedObject.OtherUpdates = new List<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase>();
            foreach (var otherUpdates in OtherUpdates)
            {
                var cloneotherUpdates = (CatraProto.Client.TL.Schemas.CloudChats.UpdateBase?)otherUpdates.Clone();
                if (cloneotherUpdates is null)
                {
                    return null;
                }

                newClonedObject.OtherUpdates.Add(cloneotherUpdates);
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
            if (other is not ChannelDifference castedOther)
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

            if (Pts != castedOther.Pts)
            {
                return true;
            }

            if (Timeout != castedOther.Timeout)
            {
                return true;
            }

            var newMessagessize = castedOther.NewMessages.Count;
            if (newMessagessize != NewMessages.Count)
            {
                return true;
            }

            for (var i = 0; i < newMessagessize; i++)
            {
                if (castedOther.NewMessages[i].Compare(NewMessages[i]))
                {
                    return true;
                }
            }

            var otherUpdatessize = castedOther.OtherUpdates.Count;
            if (otherUpdatessize != OtherUpdates.Count)
            {
                return true;
            }

            for (var i = 0; i < otherUpdatessize; i++)
            {
                if (castedOther.OtherUpdates[i].Compare(OtherUpdates[i]))
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