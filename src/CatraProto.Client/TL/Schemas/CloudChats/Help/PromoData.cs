using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class PromoData : CatraProto.Client.TL.Schemas.CloudChats.Help.PromoDataBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Proxy = 1 << 0,
            PsaType = 1 << 1,
            PsaMessage = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1942390465; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("proxy")]
        public bool Proxy { get; set; }

        [Newtonsoft.Json.JsonProperty("expires")]
        public sealed override int Expires { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("psa_type")]
        public string PsaType { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("psa_message")]
        public string PsaMessage { get; set; }


#nullable enable
        public PromoData(int expires, CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer, List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Expires = expires;
            Peer = peer;
            Chats = chats;
            Users = users;
        }
#nullable disable
        internal PromoData()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Proxy ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = PsaType == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = PsaMessage == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(Expires);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
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

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteString(PsaType);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteString(PsaMessage);
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
            Proxy = FlagsHelper.IsFlagSet(Flags, 0);
            var tryexpires = reader.ReadInt32();
            if (tryexpires.IsError)
            {
                return ReadResult<IObject>.Move(tryexpires);
            }

            Expires = tryexpires.Value;
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
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
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trypsaType = reader.ReadString();
                if (trypsaType.IsError)
                {
                    return ReadResult<IObject>.Move(trypsaType);
                }

                PsaType = trypsaType.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trypsaMessage = reader.ReadString();
                if (trypsaMessage.IsError)
                {
                    return ReadResult<IObject>.Move(trypsaMessage);
                }

                PsaMessage = trypsaMessage.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "help.promoData";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PromoData();
            newClonedObject.Flags = Flags;
            newClonedObject.Proxy = Proxy;
            newClonedObject.Expires = Expires;
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
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

            newClonedObject.PsaType = PsaType;
            newClonedObject.PsaMessage = PsaMessage;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PromoData castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Proxy != castedOther.Proxy)
            {
                return true;
            }

            if (Expires != castedOther.Expires)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
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

            if (PsaType != castedOther.PsaType)
            {
                return true;
            }

            if (PsaMessage != castedOther.PsaMessage)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}