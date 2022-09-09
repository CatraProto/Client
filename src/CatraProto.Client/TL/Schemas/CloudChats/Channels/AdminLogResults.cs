using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class AdminLogResults : CatraProto.Client.TL.Schemas.CloudChats.Channels.AdminLogResultsBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -309659827; }

        [Newtonsoft.Json.JsonProperty("events")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventBase> Events { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public AdminLogResults(List<CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventBase> events, List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Events = events;
            Chats = chats;
            Users = users;
        }
#nullable disable
        internal AdminLogResults()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkevents = writer.WriteVector(Events, false);
            if (checkevents.IsError)
            {
                return checkevents;
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
            var tryevents = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryevents.IsError)
            {
                return ReadResult<IObject>.Move(tryevents);
            }

            Events = tryevents.Value;
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
            return "channels.adminLogResults";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new AdminLogResults();
            newClonedObject.Events = new List<CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventBase>();
            foreach (var events in Events)
            {
                var cloneevents = (CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventBase?)events.Clone();
                if (cloneevents is null)
                {
                    return null;
                }

                newClonedObject.Events.Add(cloneevents);
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
            if (other is not AdminLogResults castedOther)
            {
                return true;
            }

            var eventssize = castedOther.Events.Count;
            if (eventssize != Events.Count)
            {
                return true;
            }

            for (var i = 0; i < eventssize; i++)
            {
                if (castedOther.Events[i].Compare(Events[i]))
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