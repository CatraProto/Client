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
    public partial class ChatAdminRights : CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase
    {
        [Flags]
        public enum FlagsEnum
        {
            ChangeInfo = 1 << 0,
            PostMessages = 1 << 1,
            EditMessages = 1 << 2,
            DeleteMessages = 1 << 3,
            BanUsers = 1 << 4,
            InviteUsers = 1 << 5,
            PinMessages = 1 << 7,
            AddAdmins = 1 << 9,
            Anonymous = 1 << 10,
            ManageCall = 1 << 11,
            Other = 1 << 12
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1605510357; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("change_info")]
        public sealed override bool ChangeInfo { get; set; }

        [Newtonsoft.Json.JsonProperty("post_messages")]
        public sealed override bool PostMessages { get; set; }

        [Newtonsoft.Json.JsonProperty("edit_messages")]
        public sealed override bool EditMessages { get; set; }

        [Newtonsoft.Json.JsonProperty("delete_messages")]
        public sealed override bool DeleteMessages { get; set; }

        [Newtonsoft.Json.JsonProperty("ban_users")]
        public sealed override bool BanUsers { get; set; }

        [Newtonsoft.Json.JsonProperty("invite_users")]
        public sealed override bool InviteUsers { get; set; }

        [Newtonsoft.Json.JsonProperty("pin_messages")]
        public sealed override bool PinMessages { get; set; }

        [Newtonsoft.Json.JsonProperty("add_admins")]
        public sealed override bool AddAdmins { get; set; }

        [Newtonsoft.Json.JsonProperty("anonymous")]
        public sealed override bool Anonymous { get; set; }

        [Newtonsoft.Json.JsonProperty("manage_call")]
        public sealed override bool ManageCall { get; set; }

        [Newtonsoft.Json.JsonProperty("other")]
        public sealed override bool Other { get; set; }


        public ChatAdminRights()
        {
        }

        public override void UpdateFlags()
        {
            Flags = ChangeInfo ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = PostMessages ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = EditMessages ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = DeleteMessages ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = BanUsers ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
            Flags = InviteUsers ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = PinMessages ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
            Flags = AddAdmins ? FlagsHelper.SetFlag(Flags, 9) : FlagsHelper.UnsetFlag(Flags, 9);
            Flags = Anonymous ? FlagsHelper.SetFlag(Flags, 10) : FlagsHelper.UnsetFlag(Flags, 10);
            Flags = ManageCall ? FlagsHelper.SetFlag(Flags, 11) : FlagsHelper.UnsetFlag(Flags, 11);
            Flags = Other ? FlagsHelper.SetFlag(Flags, 12) : FlagsHelper.UnsetFlag(Flags, 12);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

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
            ChangeInfo = FlagsHelper.IsFlagSet(Flags, 0);
            PostMessages = FlagsHelper.IsFlagSet(Flags, 1);
            EditMessages = FlagsHelper.IsFlagSet(Flags, 2);
            DeleteMessages = FlagsHelper.IsFlagSet(Flags, 3);
            BanUsers = FlagsHelper.IsFlagSet(Flags, 4);
            InviteUsers = FlagsHelper.IsFlagSet(Flags, 5);
            PinMessages = FlagsHelper.IsFlagSet(Flags, 7);
            AddAdmins = FlagsHelper.IsFlagSet(Flags, 9);
            Anonymous = FlagsHelper.IsFlagSet(Flags, 10);
            ManageCall = FlagsHelper.IsFlagSet(Flags, 11);
            Other = FlagsHelper.IsFlagSet(Flags, 12);
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "chatAdminRights";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChatAdminRights();
            newClonedObject.Flags = Flags;
            newClonedObject.ChangeInfo = ChangeInfo;
            newClonedObject.PostMessages = PostMessages;
            newClonedObject.EditMessages = EditMessages;
            newClonedObject.DeleteMessages = DeleteMessages;
            newClonedObject.BanUsers = BanUsers;
            newClonedObject.InviteUsers = InviteUsers;
            newClonedObject.PinMessages = PinMessages;
            newClonedObject.AddAdmins = AddAdmins;
            newClonedObject.Anonymous = Anonymous;
            newClonedObject.ManageCall = ManageCall;
            newClonedObject.Other = Other;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChatAdminRights castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (ChangeInfo != castedOther.ChangeInfo)
            {
                return true;
            }

            if (PostMessages != castedOther.PostMessages)
            {
                return true;
            }

            if (EditMessages != castedOther.EditMessages)
            {
                return true;
            }

            if (DeleteMessages != castedOther.DeleteMessages)
            {
                return true;
            }

            if (BanUsers != castedOther.BanUsers)
            {
                return true;
            }

            if (InviteUsers != castedOther.InviteUsers)
            {
                return true;
            }

            if (PinMessages != castedOther.PinMessages)
            {
                return true;
            }

            if (AddAdmins != castedOther.AddAdmins)
            {
                return true;
            }

            if (Anonymous != castedOther.Anonymous)
            {
                return true;
            }

            if (ManageCall != castedOther.ManageCall)
            {
                return true;
            }

            if (Other != castedOther.Other)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}