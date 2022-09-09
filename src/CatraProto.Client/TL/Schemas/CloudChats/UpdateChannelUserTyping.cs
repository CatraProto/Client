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
    public partial class UpdateChannelUserTyping : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            TopMsgId = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1937192669; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("channel_id")]
        public long ChannelId { get; set; }

        [Newtonsoft.Json.JsonProperty("top_msg_id")]
        public int? TopMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("from_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.PeerBase FromId { get; set; }

        [Newtonsoft.Json.JsonProperty("action")]
        public CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase Action { get; set; }


#nullable enable
        public UpdateChannelUserTyping(long channelId, CatraProto.Client.TL.Schemas.CloudChats.PeerBase fromId, CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase action)
        {
            ChannelId = channelId;
            FromId = fromId;
            Action = action;
        }
#nullable disable
        internal UpdateChannelUserTyping()
        {
        }

        public override void UpdateFlags()
        {
            Flags = TopMsgId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(ChannelId);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(TopMsgId.Value);
            }

            var checkfromId = writer.WriteObject(FromId);
            if (checkfromId.IsError)
            {
                return checkfromId;
            }

            var checkaction = writer.WriteObject(Action);
            if (checkaction.IsError)
            {
                return checkaction;
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
            var trychannelId = reader.ReadInt64();
            if (trychannelId.IsError)
            {
                return ReadResult<IObject>.Move(trychannelId);
            }

            ChannelId = trychannelId.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trytopMsgId = reader.ReadInt32();
                if (trytopMsgId.IsError)
                {
                    return ReadResult<IObject>.Move(trytopMsgId);
                }

                TopMsgId = trytopMsgId.Value;
            }

            var tryfromId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            if (tryfromId.IsError)
            {
                return ReadResult<IObject>.Move(tryfromId);
            }

            FromId = tryfromId.Value;
            var tryaction = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase>();
            if (tryaction.IsError)
            {
                return ReadResult<IObject>.Move(tryaction);
            }

            Action = tryaction.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateChannelUserTyping";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateChannelUserTyping();
            newClonedObject.Flags = Flags;
            newClonedObject.ChannelId = ChannelId;
            newClonedObject.TopMsgId = TopMsgId;
            var cloneFromId = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)FromId.Clone();
            if (cloneFromId is null)
            {
                return null;
            }

            newClonedObject.FromId = cloneFromId;
            var cloneAction = (CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase?)Action.Clone();
            if (cloneAction is null)
            {
                return null;
            }

            newClonedObject.Action = cloneAction;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateChannelUserTyping castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (ChannelId != castedOther.ChannelId)
            {
                return true;
            }

            if (TopMsgId != castedOther.TopMsgId)
            {
                return true;
            }

            if (FromId.Compare(castedOther.FromId))
            {
                return true;
            }

            if (Action.Compare(castedOther.Action))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}