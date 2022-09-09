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
    public partial class WebViewMessageSent : CatraProto.Client.TL.Schemas.CloudChats.WebViewMessageSentBase
    {
        [Flags]
        public enum FlagsEnum
        {
            MsgId = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 211046684; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("msg_id")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase MsgId { get; set; }


        public WebViewMessageSent()
        {
        }

        public override void UpdateFlags()
        {
            Flags = MsgId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkmsgId = writer.WriteObject(MsgId);
                if (checkmsgId.IsError)
                {
                    return checkmsgId;
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
                var trymsgId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase>();
                if (trymsgId.IsError)
                {
                    return ReadResult<IObject>.Move(trymsgId);
                }

                MsgId = trymsgId.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "webViewMessageSent";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new WebViewMessageSent();
            newClonedObject.Flags = Flags;
            if (MsgId is not null)
            {
                var cloneMsgId = (CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase?)MsgId.Clone();
                if (cloneMsgId is null)
                {
                    return null;
                }

                newClonedObject.MsgId = cloneMsgId;
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not WebViewMessageSent castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (MsgId is null && castedOther.MsgId is not null || MsgId is not null && castedOther.MsgId is null)
            {
                return true;
            }

            if (MsgId is not null && castedOther.MsgId is not null && MsgId.Compare(castedOther.MsgId))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}