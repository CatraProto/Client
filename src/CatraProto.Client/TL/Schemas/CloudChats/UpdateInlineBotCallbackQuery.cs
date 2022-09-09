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
    public partial class UpdateInlineBotCallbackQuery : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Data = 1 << 0,
            GameShortName = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1763610706; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("query_id")]
        public long QueryId { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("chat_instance")]
        public long ChatInstance { get; set; }

        [Newtonsoft.Json.JsonProperty("data")] public byte[] Data { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("game_short_name")]
        public string GameShortName { get; set; }


#nullable enable
        public UpdateInlineBotCallbackQuery(long queryId, long userId, CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase msgId, long chatInstance)
        {
            QueryId = queryId;
            UserId = userId;
            MsgId = msgId;
            ChatInstance = chatInstance;
        }
#nullable disable
        internal UpdateInlineBotCallbackQuery()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Data == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = GameShortName == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(QueryId);
            writer.WriteInt64(UserId);
            var checkmsgId = writer.WriteObject(MsgId);
            if (checkmsgId.IsError)
            {
                return checkmsgId;
            }

            writer.WriteInt64(ChatInstance);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteBytes(Data);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteString(GameShortName);
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
            var tryqueryId = reader.ReadInt64();
            if (tryqueryId.IsError)
            {
                return ReadResult<IObject>.Move(tryqueryId);
            }

            QueryId = tryqueryId.Value;
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
            var trymsgId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase>();
            if (trymsgId.IsError)
            {
                return ReadResult<IObject>.Move(trymsgId);
            }

            MsgId = trymsgId.Value;
            var trychatInstance = reader.ReadInt64();
            if (trychatInstance.IsError)
            {
                return ReadResult<IObject>.Move(trychatInstance);
            }

            ChatInstance = trychatInstance.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trydata = reader.ReadBytes();
                if (trydata.IsError)
                {
                    return ReadResult<IObject>.Move(trydata);
                }

                Data = trydata.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trygameShortName = reader.ReadString();
                if (trygameShortName.IsError)
                {
                    return ReadResult<IObject>.Move(trygameShortName);
                }

                GameShortName = trygameShortName.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateInlineBotCallbackQuery";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateInlineBotCallbackQuery();
            newClonedObject.Flags = Flags;
            newClonedObject.QueryId = QueryId;
            newClonedObject.UserId = UserId;
            var cloneMsgId = (CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase?)MsgId.Clone();
            if (cloneMsgId is null)
            {
                return null;
            }

            newClonedObject.MsgId = cloneMsgId;
            newClonedObject.ChatInstance = ChatInstance;
            newClonedObject.Data = Data;
            newClonedObject.GameShortName = GameShortName;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateInlineBotCallbackQuery castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (QueryId != castedOther.QueryId)
            {
                return true;
            }

            if (UserId != castedOther.UserId)
            {
                return true;
            }

            if (MsgId.Compare(castedOther.MsgId))
            {
                return true;
            }

            if (ChatInstance != castedOther.ChatInstance)
            {
                return true;
            }

            if (Data != castedOther.Data)
            {
                return true;
            }

            if (GameShortName != castedOther.GameShortName)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}