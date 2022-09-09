using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class BotCallbackAnswer : CatraProto.Client.TL.Schemas.CloudChats.Messages.BotCallbackAnswerBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Alert = 1 << 1,
            HasUrl = 1 << 3,
            NativeUi = 1 << 4,
            Message = 1 << 0,
            Url = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 911761060; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("alert")]
        public sealed override bool Alert { get; set; }

        [Newtonsoft.Json.JsonProperty("has_url")]
        public sealed override bool HasUrl { get; set; }

        [Newtonsoft.Json.JsonProperty("native_ui")]
        public sealed override bool NativeUi { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("message")]
        public sealed override string Message { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("url")]
        public sealed override string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("cache_time")]
        public sealed override int CacheTime { get; set; }


#nullable enable
        public BotCallbackAnswer(int cacheTime)
        {
            CacheTime = cacheTime;
        }
#nullable disable
        internal BotCallbackAnswer()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Alert ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = HasUrl ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = NativeUi ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
            Flags = Message == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Url == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteString(Message);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteString(Url);
            }

            writer.WriteInt32(CacheTime);

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
            Alert = FlagsHelper.IsFlagSet(Flags, 1);
            HasUrl = FlagsHelper.IsFlagSet(Flags, 3);
            NativeUi = FlagsHelper.IsFlagSet(Flags, 4);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trymessage = reader.ReadString();
                if (trymessage.IsError)
                {
                    return ReadResult<IObject>.Move(trymessage);
                }

                Message = trymessage.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryurl = reader.ReadString();
                if (tryurl.IsError)
                {
                    return ReadResult<IObject>.Move(tryurl);
                }

                Url = tryurl.Value;
            }

            var trycacheTime = reader.ReadInt32();
            if (trycacheTime.IsError)
            {
                return ReadResult<IObject>.Move(trycacheTime);
            }

            CacheTime = trycacheTime.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.botCallbackAnswer";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new BotCallbackAnswer();
            newClonedObject.Flags = Flags;
            newClonedObject.Alert = Alert;
            newClonedObject.HasUrl = HasUrl;
            newClonedObject.NativeUi = NativeUi;
            newClonedObject.Message = Message;
            newClonedObject.Url = Url;
            newClonedObject.CacheTime = CacheTime;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not BotCallbackAnswer castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Alert != castedOther.Alert)
            {
                return true;
            }

            if (HasUrl != castedOther.HasUrl)
            {
                return true;
            }

            if (NativeUi != castedOther.NativeUi)
            {
                return true;
            }

            if (Message != castedOther.Message)
            {
                return true;
            }

            if (Url != castedOther.Url)
            {
                return true;
            }

            if (CacheTime != castedOther.CacheTime)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}