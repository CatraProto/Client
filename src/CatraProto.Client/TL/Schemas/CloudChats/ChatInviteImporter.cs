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
    public partial class ChatInviteImporter : CatraProto.Client.TL.Schemas.CloudChats.ChatInviteImporterBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Requested = 1 << 0,
            About = 1 << 2,
            ApprovedBy = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1940201511; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("requested")]
        public sealed override bool Requested { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public sealed override long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public sealed override int Date { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("about")]
        public sealed override string About { get; set; }

        [Newtonsoft.Json.JsonProperty("approved_by")]
        public sealed override long? ApprovedBy { get; set; }


#nullable enable
        public ChatInviteImporter(long userId, int date)
        {
            UserId = userId;
            Date = date;
        }
#nullable disable
        internal ChatInviteImporter()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Requested ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = About == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = ApprovedBy == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(UserId);
            writer.WriteInt32(Date);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteString(About);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt64(ApprovedBy.Value);
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
            Requested = FlagsHelper.IsFlagSet(Flags, 0);
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryabout = reader.ReadString();
                if (tryabout.IsError)
                {
                    return ReadResult<IObject>.Move(tryabout);
                }

                About = tryabout.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryapprovedBy = reader.ReadInt64();
                if (tryapprovedBy.IsError)
                {
                    return ReadResult<IObject>.Move(tryapprovedBy);
                }

                ApprovedBy = tryapprovedBy.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "chatInviteImporter";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChatInviteImporter();
            newClonedObject.Flags = Flags;
            newClonedObject.Requested = Requested;
            newClonedObject.UserId = UserId;
            newClonedObject.Date = Date;
            newClonedObject.About = About;
            newClonedObject.ApprovedBy = ApprovedBy;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChatInviteImporter castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Requested != castedOther.Requested)
            {
                return true;
            }

            if (UserId != castedOther.UserId)
            {
                return true;
            }

            if (Date != castedOther.Date)
            {
                return true;
            }

            if (About != castedOther.About)
            {
                return true;
            }

            if (ApprovedBy != castedOther.ApprovedBy)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}