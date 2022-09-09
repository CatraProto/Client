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
    public partial class ApiUpdates : CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1957577280; }

        [Newtonsoft.Json.JsonProperty("updates")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase> Updates { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("seq")] public int Seq { get; set; }


#nullable enable
        public ApiUpdates(List<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase> updates, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users, List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, int date, int seq)
        {
            Updates = updates;
            Users = users;
            Chats = chats;
            Date = date;
            Seq = seq;
        }
#nullable disable
        internal ApiUpdates()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkupdates = writer.WriteVector(Updates, false);
            if (checkupdates.IsError)
            {
                return checkupdates;
            }

            var checkusers = writer.WriteVector(Users, false);
            if (checkusers.IsError)
            {
                return checkusers;
            }

            var checkchats = writer.WriteVector(Chats, false);
            if (checkchats.IsError)
            {
                return checkchats;
            }

            writer.WriteInt32(Date);
            writer.WriteInt32(Seq);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryupdates = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryupdates.IsError)
            {
                return ReadResult<IObject>.Move(tryupdates);
            }

            Updates = tryupdates.Value;
            var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryusers.IsError)
            {
                return ReadResult<IObject>.Move(tryusers);
            }

            Users = tryusers.Value;
            var trychats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trychats.IsError)
            {
                return ReadResult<IObject>.Move(trychats);
            }

            Chats = trychats.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            var tryseq = reader.ReadInt32();
            if (tryseq.IsError)
            {
                return ReadResult<IObject>.Move(tryseq);
            }

            Seq = tryseq.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updates";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ApiUpdates();
            newClonedObject.Updates = new List<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase>();
            foreach (var updates in Updates)
            {
                var cloneupdates = (CatraProto.Client.TL.Schemas.CloudChats.UpdateBase?)updates.Clone();
                if (cloneupdates is null)
                {
                    return null;
                }

                newClonedObject.Updates.Add(cloneupdates);
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

            newClonedObject.Date = Date;
            newClonedObject.Seq = Seq;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ApiUpdates castedOther)
            {
                return true;
            }

            var updatessize = castedOther.Updates.Count;
            if (updatessize != Updates.Count)
            {
                return true;
            }

            for (var i = 0; i < updatessize; i++)
            {
                if (castedOther.Updates[i].Compare(Updates[i]))
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

            if (Date != castedOther.Date)
            {
                return true;
            }

            if (Seq != castedOther.Seq)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}