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
    public partial class MessageReactionsList : CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageReactionsListBase
    {
        [Flags]
        public enum FlagsEnum
        {
            NextOffset = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 834488621; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("count")]
        public sealed override int Count { get; set; }

        [Newtonsoft.Json.JsonProperty("reactions")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.MessagePeerReactionBase> Reactions { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("next_offset")]
        public sealed override string NextOffset { get; set; }


#nullable enable
        public MessageReactionsList(int count, List<CatraProto.Client.TL.Schemas.CloudChats.MessagePeerReactionBase> reactions, List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Count = count;
            Reactions = reactions;
            Chats = chats;
            Users = users;
        }
#nullable disable
        internal MessageReactionsList()
        {
        }

        public override void UpdateFlags()
        {
            Flags = NextOffset == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(Count);
            var checkreactions = writer.WriteVector(Reactions, false);
            if (checkreactions.IsError)
            {
                return checkreactions;
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

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteString(NextOffset);
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
            var trycount = reader.ReadInt32();
            if (trycount.IsError)
            {
                return ReadResult<IObject>.Move(trycount);
            }

            Count = trycount.Value;
            var tryreactions = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessagePeerReactionBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryreactions.IsError)
            {
                return ReadResult<IObject>.Move(tryreactions);
            }

            Reactions = tryreactions.Value;
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
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trynextOffset = reader.ReadString();
                if (trynextOffset.IsError)
                {
                    return ReadResult<IObject>.Move(trynextOffset);
                }

                NextOffset = trynextOffset.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.messageReactionsList";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageReactionsList();
            newClonedObject.Flags = Flags;
            newClonedObject.Count = Count;
            newClonedObject.Reactions = new List<CatraProto.Client.TL.Schemas.CloudChats.MessagePeerReactionBase>();
            foreach (var reactions in Reactions)
            {
                var clonereactions = (CatraProto.Client.TL.Schemas.CloudChats.MessagePeerReactionBase?)reactions.Clone();
                if (clonereactions is null)
                {
                    return null;
                }

                newClonedObject.Reactions.Add(clonereactions);
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

            newClonedObject.NextOffset = NextOffset;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageReactionsList castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Count != castedOther.Count)
            {
                return true;
            }

            var reactionssize = castedOther.Reactions.Count;
            if (reactionssize != Reactions.Count)
            {
                return true;
            }

            for (var i = 0; i < reactionssize; i++)
            {
                if (castedOther.Reactions[i].Compare(Reactions[i]))
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

            if (NextOffset != castedOther.NextOffset)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}