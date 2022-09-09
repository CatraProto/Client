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
    public partial class SetBotCallbackAnswer : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Alert = 1 << 1,
            Message = 1 << 0,
            Url = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -712043766; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("alert")]
        public bool Alert { get; set; }

        [Newtonsoft.Json.JsonProperty("query_id")]
        public long QueryId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("message")]
        public string Message { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("url")]
        public string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("cache_time")]
        public int CacheTime { get; set; }


#nullable enable
        public SetBotCallbackAnswer(long queryId, int cacheTime)
        {
            QueryId = queryId;
            CacheTime = cacheTime;
        }
#nullable disable

        internal SetBotCallbackAnswer()
        {
        }

        public void UpdateFlags()
        {
            Flags = Alert ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Message == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Url == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(QueryId);
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

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            Alert = FlagsHelper.IsFlagSet(Flags, 1);
            var tryqueryId = reader.ReadInt64();
            if (tryqueryId.IsError)
            {
                return ReadResult<IObject>.Move(tryqueryId);
            }

            QueryId = tryqueryId.Value;
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
            return "messages.setBotCallbackAnswer";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SetBotCallbackAnswer();
            newClonedObject.Flags = Flags;
            newClonedObject.Alert = Alert;
            newClonedObject.QueryId = QueryId;
            newClonedObject.Message = Message;
            newClonedObject.Url = Url;
            newClonedObject.CacheTime = CacheTime;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SetBotCallbackAnswer castedOther)
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

            if (QueryId != castedOther.QueryId)
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