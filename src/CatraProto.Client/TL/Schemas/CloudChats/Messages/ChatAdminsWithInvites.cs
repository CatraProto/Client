using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class ChatAdminsWithInvites : CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatAdminsWithInvitesBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1231326505; }

        [Newtonsoft.Json.JsonProperty("admins")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ChatAdminWithInvitesBase> Admins { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public ChatAdminsWithInvites(List<CatraProto.Client.TL.Schemas.CloudChats.ChatAdminWithInvitesBase> admins, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Admins = admins;
            Users = users;

        }
#nullable disable
        internal ChatAdminsWithInvites()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkadmins = writer.WriteVector(Admins, false);
            if (checkadmins.IsError)
            {
                return checkadmins;
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
            var tryadmins = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatAdminWithInvitesBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryadmins.IsError)
            {
                return ReadResult<IObject>.Move(tryadmins);
            }
            Admins = tryadmins.Value;
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
            return "messages.chatAdminsWithInvites";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}