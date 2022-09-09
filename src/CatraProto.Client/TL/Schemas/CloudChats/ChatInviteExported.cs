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
    public partial class ChatInviteExported : CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Revoked = 1 << 0,
            Permanent = 1 << 5,
            RequestNeeded = 1 << 6,
            StartDate = 1 << 4,
            ExpireDate = 1 << 1,
            UsageLimit = 1 << 2,
            Usage = 1 << 3,
            Requested = 1 << 7,
            Title = 1 << 8
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 179611673; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("revoked")]
        public bool Revoked { get; set; }

        [Newtonsoft.Json.JsonProperty("permanent")]
        public bool Permanent { get; set; }

        [Newtonsoft.Json.JsonProperty("request_needed")]
        public bool RequestNeeded { get; set; }

        [Newtonsoft.Json.JsonProperty("link")] public string Link { get; set; }

        [Newtonsoft.Json.JsonProperty("admin_id")]
        public long AdminId { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("start_date")]
        public int? StartDate { get; set; }

        [Newtonsoft.Json.JsonProperty("expire_date")]
        public int? ExpireDate { get; set; }

        [Newtonsoft.Json.JsonProperty("usage_limit")]
        public int? UsageLimit { get; set; }

        [Newtonsoft.Json.JsonProperty("usage")]
        public int? Usage { get; set; }

        [Newtonsoft.Json.JsonProperty("requested")]
        public int? Requested { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }


#nullable enable
        public ChatInviteExported(string link, long adminId, int date)
        {
            Link = link;
            AdminId = adminId;
            Date = date;
        }
#nullable disable
        internal ChatInviteExported()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Revoked ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Permanent ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = RequestNeeded ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
            Flags = StartDate == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
            Flags = ExpireDate == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = UsageLimit == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = Usage == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = Requested == null ? FlagsHelper.UnsetFlag(Flags, 7) : FlagsHelper.SetFlag(Flags, 7);
            Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 8) : FlagsHelper.SetFlag(Flags, 8);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Link);
            writer.WriteInt64(AdminId);
            writer.WriteInt32(Date);
            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.WriteInt32(StartDate.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt32(ExpireDate.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteInt32(UsageLimit.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.WriteInt32(Usage.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 7))
            {
                writer.WriteInt32(Requested.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 8))
            {
                writer.WriteString(Title);
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
            Revoked = FlagsHelper.IsFlagSet(Flags, 0);
            Permanent = FlagsHelper.IsFlagSet(Flags, 5);
            RequestNeeded = FlagsHelper.IsFlagSet(Flags, 6);
            var trylink = reader.ReadString();
            if (trylink.IsError)
            {
                return ReadResult<IObject>.Move(trylink);
            }

            Link = trylink.Value;
            var tryadminId = reader.ReadInt64();
            if (tryadminId.IsError)
            {
                return ReadResult<IObject>.Move(tryadminId);
            }

            AdminId = tryadminId.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var trystartDate = reader.ReadInt32();
                if (trystartDate.IsError)
                {
                    return ReadResult<IObject>.Move(trystartDate);
                }

                StartDate = trystartDate.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryexpireDate = reader.ReadInt32();
                if (tryexpireDate.IsError)
                {
                    return ReadResult<IObject>.Move(tryexpireDate);
                }

                ExpireDate = tryexpireDate.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryusageLimit = reader.ReadInt32();
                if (tryusageLimit.IsError)
                {
                    return ReadResult<IObject>.Move(tryusageLimit);
                }

                UsageLimit = tryusageLimit.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var tryusage = reader.ReadInt32();
                if (tryusage.IsError)
                {
                    return ReadResult<IObject>.Move(tryusage);
                }

                Usage = tryusage.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 7))
            {
                var tryrequested = reader.ReadInt32();
                if (tryrequested.IsError)
                {
                    return ReadResult<IObject>.Move(tryrequested);
                }

                Requested = tryrequested.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 8))
            {
                var trytitle = reader.ReadString();
                if (trytitle.IsError)
                {
                    return ReadResult<IObject>.Move(trytitle);
                }

                Title = trytitle.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "chatInviteExported";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChatInviteExported();
            newClonedObject.Flags = Flags;
            newClonedObject.Revoked = Revoked;
            newClonedObject.Permanent = Permanent;
            newClonedObject.RequestNeeded = RequestNeeded;
            newClonedObject.Link = Link;
            newClonedObject.AdminId = AdminId;
            newClonedObject.Date = Date;
            newClonedObject.StartDate = StartDate;
            newClonedObject.ExpireDate = ExpireDate;
            newClonedObject.UsageLimit = UsageLimit;
            newClonedObject.Usage = Usage;
            newClonedObject.Requested = Requested;
            newClonedObject.Title = Title;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChatInviteExported castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Revoked != castedOther.Revoked)
            {
                return true;
            }

            if (Permanent != castedOther.Permanent)
            {
                return true;
            }

            if (RequestNeeded != castedOther.RequestNeeded)
            {
                return true;
            }

            if (Link != castedOther.Link)
            {
                return true;
            }

            if (AdminId != castedOther.AdminId)
            {
                return true;
            }

            if (Date != castedOther.Date)
            {
                return true;
            }

            if (StartDate != castedOther.StartDate)
            {
                return true;
            }

            if (ExpireDate != castedOther.ExpireDate)
            {
                return true;
            }

            if (UsageLimit != castedOther.UsageLimit)
            {
                return true;
            }

            if (Usage != castedOther.Usage)
            {
                return true;
            }

            if (Requested != castedOther.Requested)
            {
                return true;
            }

            if (Title != castedOther.Title)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}