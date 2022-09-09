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
    public partial class SearchResultsCalendar : CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchResultsCalendarBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Inexact = 1 << 0,
            OffsetIdOffset = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 343859772; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("inexact")]
        public sealed override bool Inexact { get; set; }

        [Newtonsoft.Json.JsonProperty("count")]
        public sealed override int Count { get; set; }

        [Newtonsoft.Json.JsonProperty("min_date")]
        public sealed override int MinDate { get; set; }

        [Newtonsoft.Json.JsonProperty("min_msg_id")]
        public sealed override int MinMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("offset_id_offset")]
        public sealed override int? OffsetIdOffset { get; set; }

        [Newtonsoft.Json.JsonProperty("periods")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.SearchResultsCalendarPeriodBase> Periods { get; set; }

        [Newtonsoft.Json.JsonProperty("messages")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> Messages { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public SearchResultsCalendar(int count, int minDate, int minMsgId, List<CatraProto.Client.TL.Schemas.CloudChats.SearchResultsCalendarPeriodBase> periods, List<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> messages, List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Count = count;
            MinDate = minDate;
            MinMsgId = minMsgId;
            Periods = periods;
            Messages = messages;
            Chats = chats;
            Users = users;
        }
#nullable disable
        internal SearchResultsCalendar()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Inexact ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = OffsetIdOffset == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(Count);
            writer.WriteInt32(MinDate);
            writer.WriteInt32(MinMsgId);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt32(OffsetIdOffset.Value);
            }

            var checkperiods = writer.WriteVector(Periods, false);
            if (checkperiods.IsError)
            {
                return checkperiods;
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
            Inexact = FlagsHelper.IsFlagSet(Flags, 0);
            var trycount = reader.ReadInt32();
            if (trycount.IsError)
            {
                return ReadResult<IObject>.Move(trycount);
            }

            Count = trycount.Value;
            var tryminDate = reader.ReadInt32();
            if (tryminDate.IsError)
            {
                return ReadResult<IObject>.Move(tryminDate);
            }

            MinDate = tryminDate.Value;
            var tryminMsgId = reader.ReadInt32();
            if (tryminMsgId.IsError)
            {
                return ReadResult<IObject>.Move(tryminMsgId);
            }

            MinMsgId = tryminMsgId.Value;
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryoffsetIdOffset = reader.ReadInt32();
                if (tryoffsetIdOffset.IsError)
                {
                    return ReadResult<IObject>.Move(tryoffsetIdOffset);
                }

                OffsetIdOffset = tryoffsetIdOffset.Value;
            }

            var tryperiods = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SearchResultsCalendarPeriodBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryperiods.IsError)
            {
                return ReadResult<IObject>.Move(tryperiods);
            }

            Periods = tryperiods.Value;
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
            return "messages.searchResultsCalendar";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SearchResultsCalendar();
            newClonedObject.Flags = Flags;
            newClonedObject.Inexact = Inexact;
            newClonedObject.Count = Count;
            newClonedObject.MinDate = MinDate;
            newClonedObject.MinMsgId = MinMsgId;
            newClonedObject.OffsetIdOffset = OffsetIdOffset;
            newClonedObject.Periods = new List<CatraProto.Client.TL.Schemas.CloudChats.SearchResultsCalendarPeriodBase>();
            foreach (var periods in Periods)
            {
                var cloneperiods = (CatraProto.Client.TL.Schemas.CloudChats.SearchResultsCalendarPeriodBase?)periods.Clone();
                if (cloneperiods is null)
                {
                    return null;
                }

                newClonedObject.Periods.Add(cloneperiods);
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
            if (other is not SearchResultsCalendar castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Inexact != castedOther.Inexact)
            {
                return true;
            }

            if (Count != castedOther.Count)
            {
                return true;
            }

            if (MinDate != castedOther.MinDate)
            {
                return true;
            }

            if (MinMsgId != castedOther.MinMsgId)
            {
                return true;
            }

            if (OffsetIdOffset != castedOther.OffsetIdOffset)
            {
                return true;
            }

            var periodssize = castedOther.Periods.Count;
            if (periodssize != Periods.Count)
            {
                return true;
            }

            for (var i = 0; i < periodssize; i++)
            {
                if (castedOther.Periods[i].Compare(Periods[i]))
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