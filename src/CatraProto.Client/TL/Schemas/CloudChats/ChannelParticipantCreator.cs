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
    public partial class ChannelParticipantCreator : CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Rank = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 803602899; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("admin_rights")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase AdminRights { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("rank")]
        public string Rank { get; set; }


#nullable enable
        public ChannelParticipantCreator(long userId, CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase adminRights)
        {
            UserId = userId;
            AdminRights = adminRights;
        }
#nullable disable
        internal ChannelParticipantCreator()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Rank == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(UserId);
            var checkadminRights = writer.WriteObject(AdminRights);
            if (checkadminRights.IsError)
            {
                return checkadminRights;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteString(Rank);
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
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
            var tryadminRights = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase>();
            if (tryadminRights.IsError)
            {
                return ReadResult<IObject>.Move(tryadminRights);
            }

            AdminRights = tryadminRights.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryrank = reader.ReadString();
                if (tryrank.IsError)
                {
                    return ReadResult<IObject>.Move(tryrank);
                }

                Rank = tryrank.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channelParticipantCreator";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelParticipantCreator();
            newClonedObject.Flags = Flags;
            newClonedObject.UserId = UserId;
            var cloneAdminRights = (CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase?)AdminRights.Clone();
            if (cloneAdminRights is null)
            {
                return null;
            }

            newClonedObject.AdminRights = cloneAdminRights;
            newClonedObject.Rank = Rank;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChannelParticipantCreator castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (UserId != castedOther.UserId)
            {
                return true;
            }

            if (AdminRights.Compare(castedOther.AdminRights))
            {
                return true;
            }

            if (Rank != castedOther.Rank)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}