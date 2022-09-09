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
    public partial class RecentMeUrlChat : CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1294306862; }

        [Newtonsoft.Json.JsonProperty("url")] public sealed override string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public long ChatId { get; set; }


#nullable enable
        public RecentMeUrlChat(string url, long chatId)
        {
            Url = url;
            ChatId = chatId;
        }
#nullable disable
        internal RecentMeUrlChat()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Url);
            writer.WriteInt64(ChatId);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryurl = reader.ReadString();
            if (tryurl.IsError)
            {
                return ReadResult<IObject>.Move(tryurl);
            }

            Url = tryurl.Value;
            var trychatId = reader.ReadInt64();
            if (trychatId.IsError)
            {
                return ReadResult<IObject>.Move(trychatId);
            }

            ChatId = trychatId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "recentMeUrlChat";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new RecentMeUrlChat();
            newClonedObject.Url = Url;
            newClonedObject.ChatId = ChatId;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not RecentMeUrlChat castedOther)
            {
                return true;
            }

            if (Url != castedOther.Url)
            {
                return true;
            }

            if (ChatId != castedOther.ChatId)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}