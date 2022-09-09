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
    public partial class MessageFwdHeader : CatraProto.Client.TL.Schemas.CloudChats.MessageFwdHeaderBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Imported = 1 << 7,
            FromId = 1 << 0,
            FromName = 1 << 5,
            ChannelPost = 1 << 2,
            PostAuthor = 1 << 3,
            SavedFromPeer = 1 << 4,
            SavedFromMsgId = 1 << 4,
            PsaType = 1 << 6
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1601666510; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("imported")]
        public sealed override bool Imported { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("from_id")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerBase FromId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("from_name")]
        public sealed override string FromName { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public sealed override int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("channel_post")]
        public sealed override int? ChannelPost { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("post_author")]
        public sealed override string PostAuthor { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("saved_from_peer")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerBase SavedFromPeer { get; set; }

        [Newtonsoft.Json.JsonProperty("saved_from_msg_id")]
        public sealed override int? SavedFromMsgId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("psa_type")]
        public sealed override string PsaType { get; set; }


#nullable enable
        public MessageFwdHeader(int date)
        {
            Date = date;
        }
#nullable disable
        internal MessageFwdHeader()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Imported ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
            Flags = FromId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = FromName == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
            Flags = ChannelPost == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = PostAuthor == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = SavedFromPeer == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
            Flags = SavedFromMsgId == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
            Flags = PsaType == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkfromId = writer.WriteObject(FromId);
                if (checkfromId.IsError)
                {
                    return checkfromId;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                writer.WriteString(FromName);
            }

            writer.WriteInt32(Date);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteInt32(ChannelPost.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.WriteString(PostAuthor);
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var checksavedFromPeer = writer.WriteObject(SavedFromPeer);
                if (checksavedFromPeer.IsError)
                {
                    return checksavedFromPeer;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.WriteInt32(SavedFromMsgId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                writer.WriteString(PsaType);
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
            Imported = FlagsHelper.IsFlagSet(Flags, 7);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryfromId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
                if (tryfromId.IsError)
                {
                    return ReadResult<IObject>.Move(tryfromId);
                }

                FromId = tryfromId.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                var tryfromName = reader.ReadString();
                if (tryfromName.IsError)
                {
                    return ReadResult<IObject>.Move(tryfromName);
                }

                FromName = tryfromName.Value;
            }

            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trychannelPost = reader.ReadInt32();
                if (trychannelPost.IsError)
                {
                    return ReadResult<IObject>.Move(trychannelPost);
                }

                ChannelPost = trychannelPost.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var trypostAuthor = reader.ReadString();
                if (trypostAuthor.IsError)
                {
                    return ReadResult<IObject>.Move(trypostAuthor);
                }

                PostAuthor = trypostAuthor.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var trysavedFromPeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
                if (trysavedFromPeer.IsError)
                {
                    return ReadResult<IObject>.Move(trysavedFromPeer);
                }

                SavedFromPeer = trysavedFromPeer.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var trysavedFromMsgId = reader.ReadInt32();
                if (trysavedFromMsgId.IsError)
                {
                    return ReadResult<IObject>.Move(trysavedFromMsgId);
                }

                SavedFromMsgId = trysavedFromMsgId.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                var trypsaType = reader.ReadString();
                if (trypsaType.IsError)
                {
                    return ReadResult<IObject>.Move(trypsaType);
                }

                PsaType = trypsaType.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messageFwdHeader";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageFwdHeader();
            newClonedObject.Flags = Flags;
            newClonedObject.Imported = Imported;
            if (FromId is not null)
            {
                var cloneFromId = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)FromId.Clone();
                if (cloneFromId is null)
                {
                    return null;
                }

                newClonedObject.FromId = cloneFromId;
            }

            newClonedObject.FromName = FromName;
            newClonedObject.Date = Date;
            newClonedObject.ChannelPost = ChannelPost;
            newClonedObject.PostAuthor = PostAuthor;
            if (SavedFromPeer is not null)
            {
                var cloneSavedFromPeer = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)SavedFromPeer.Clone();
                if (cloneSavedFromPeer is null)
                {
                    return null;
                }

                newClonedObject.SavedFromPeer = cloneSavedFromPeer;
            }

            newClonedObject.SavedFromMsgId = SavedFromMsgId;
            newClonedObject.PsaType = PsaType;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageFwdHeader castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Imported != castedOther.Imported)
            {
                return true;
            }

            if (FromId is null && castedOther.FromId is not null || FromId is not null && castedOther.FromId is null)
            {
                return true;
            }

            if (FromId is not null && castedOther.FromId is not null && FromId.Compare(castedOther.FromId))
            {
                return true;
            }

            if (FromName != castedOther.FromName)
            {
                return true;
            }

            if (Date != castedOther.Date)
            {
                return true;
            }

            if (ChannelPost != castedOther.ChannelPost)
            {
                return true;
            }

            if (PostAuthor != castedOther.PostAuthor)
            {
                return true;
            }

            if (SavedFromPeer is null && castedOther.SavedFromPeer is not null || SavedFromPeer is not null && castedOther.SavedFromPeer is null)
            {
                return true;
            }

            if (SavedFromPeer is not null && castedOther.SavedFromPeer is not null && SavedFromPeer.Compare(castedOther.SavedFromPeer))
            {
                return true;
            }

            if (SavedFromMsgId != castedOther.SavedFromMsgId)
            {
                return true;
            }

            if (PsaType != castedOther.PsaType)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}