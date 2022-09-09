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
    public partial class MessageViews : CatraProto.Client.TL.Schemas.CloudChats.MessageViewsBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Views = 1 << 0,
            Forwards = 1 << 1,
            Replies = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1163625789; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("views")]
        public sealed override int? Views { get; set; }

        [Newtonsoft.Json.JsonProperty("forwards")]
        public sealed override int? Forwards { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("replies")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.MessageRepliesBase Replies { get; set; }


        public MessageViews()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Views == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Forwards == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = Replies == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(Views.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt32(Forwards.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var checkreplies = writer.WriteObject(Replies);
                if (checkreplies.IsError)
                {
                    return checkreplies;
                }
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
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryviews = reader.ReadInt32();
                if (tryviews.IsError)
                {
                    return ReadResult<IObject>.Move(tryviews);
                }

                Views = tryviews.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryforwards = reader.ReadInt32();
                if (tryforwards.IsError)
                {
                    return ReadResult<IObject>.Move(tryforwards);
                }

                Forwards = tryforwards.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryreplies = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.MessageRepliesBase>();
                if (tryreplies.IsError)
                {
                    return ReadResult<IObject>.Move(tryreplies);
                }

                Replies = tryreplies.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messageViews";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageViews();
            newClonedObject.Flags = Flags;
            newClonedObject.Views = Views;
            newClonedObject.Forwards = Forwards;
            if (Replies is not null)
            {
                var cloneReplies = (CatraProto.Client.TL.Schemas.CloudChats.MessageRepliesBase?)Replies.Clone();
                if (cloneReplies is null)
                {
                    return null;
                }

                newClonedObject.Replies = cloneReplies;
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageViews castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Views != castedOther.Views)
            {
                return true;
            }

            if (Forwards != castedOther.Forwards)
            {
                return true;
            }

            if (Replies is null && castedOther.Replies is not null || Replies is not null && castedOther.Replies is null)
            {
                return true;
            }

            if (Replies is not null && castedOther.Replies is not null && Replies.Compare(castedOther.Replies))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}