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
    public partial class ChannelAdminLogEventActionExportedInviteEdit : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -384910503; }

        [Newtonsoft.Json.JsonProperty("prev_invite")]
        public CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase PrevInvite { get; set; }

        [Newtonsoft.Json.JsonProperty("new_invite")]
        public CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase NewInvite { get; set; }


#nullable enable
        public ChannelAdminLogEventActionExportedInviteEdit(CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase prevInvite, CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase newInvite)
        {
            PrevInvite = prevInvite;
            NewInvite = newInvite;
        }
#nullable disable
        internal ChannelAdminLogEventActionExportedInviteEdit()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkprevInvite = writer.WriteObject(PrevInvite);
            if (checkprevInvite.IsError)
            {
                return checkprevInvite;
            }

            var checknewInvite = writer.WriteObject(NewInvite);
            if (checknewInvite.IsError)
            {
                return checknewInvite;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryprevInvite = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>();
            if (tryprevInvite.IsError)
            {
                return ReadResult<IObject>.Move(tryprevInvite);
            }

            PrevInvite = tryprevInvite.Value;
            var trynewInvite = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>();
            if (trynewInvite.IsError)
            {
                return ReadResult<IObject>.Move(trynewInvite);
            }

            NewInvite = trynewInvite.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channelAdminLogEventActionExportedInviteEdit";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelAdminLogEventActionExportedInviteEdit();
            var clonePrevInvite = (CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase?)PrevInvite.Clone();
            if (clonePrevInvite is null)
            {
                return null;
            }

            newClonedObject.PrevInvite = clonePrevInvite;
            var cloneNewInvite = (CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase?)NewInvite.Clone();
            if (cloneNewInvite is null)
            {
                return null;
            }

            newClonedObject.NewInvite = cloneNewInvite;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChannelAdminLogEventActionExportedInviteEdit castedOther)
            {
                return true;
            }

            if (PrevInvite.Compare(castedOther.PrevInvite))
            {
                return true;
            }

            if (NewInvite.Compare(castedOther.NewInvite))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}