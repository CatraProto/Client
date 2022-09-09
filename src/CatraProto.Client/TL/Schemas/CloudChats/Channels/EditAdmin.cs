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
    public partial class EditAdmin : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -751007486; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("channel")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("admin_rights")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase AdminRights { get; set; }

        [Newtonsoft.Json.JsonProperty("rank")] public string Rank { get; set; }


#nullable enable
        public EditAdmin(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase adminRights, string rank)
        {
            Channel = channel;
            UserId = userId;
            AdminRights = adminRights;
            Rank = rank;
        }
#nullable disable

        internal EditAdmin()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkchannel = writer.WriteObject(Channel);
            if (checkchannel.IsError)
            {
                return checkchannel;
            }

            var checkuserId = writer.WriteObject(UserId);
            if (checkuserId.IsError)
            {
                return checkuserId;
            }

            var checkadminRights = writer.WriteObject(AdminRights);
            if (checkadminRights.IsError)
            {
                return checkadminRights;
            }

            writer.WriteString(Rank);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trychannel = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
            if (trychannel.IsError)
            {
                return ReadResult<IObject>.Move(trychannel);
            }

            Channel = trychannel.Value;
            var tryuserId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
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
            var tryrank = reader.ReadString();
            if (tryrank.IsError)
            {
                return ReadResult<IObject>.Move(tryrank);
            }

            Rank = tryrank.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channels.editAdmin";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new EditAdmin();
            var cloneChannel = (CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase?)Channel.Clone();
            if (cloneChannel is null)
            {
                return null;
            }

            newClonedObject.Channel = cloneChannel;
            var cloneUserId = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)UserId.Clone();
            if (cloneUserId is null)
            {
                return null;
            }

            newClonedObject.UserId = cloneUserId;
            var cloneAdminRights = (CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase?)AdminRights.Clone();
            if (cloneAdminRights is null)
            {
                return null;
            }

            newClonedObject.AdminRights = cloneAdminRights;
            newClonedObject.Rank = Rank;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not EditAdmin castedOther)
            {
                return true;
            }

            if (Channel.Compare(castedOther.Channel))
            {
                return true;
            }

            if (UserId.Compare(castedOther.UserId))
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