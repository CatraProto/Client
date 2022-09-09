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
    public partial class RecentMeUrlUser : CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1188296222; }

        [Newtonsoft.Json.JsonProperty("url")] public sealed override string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }


#nullable enable
        public RecentMeUrlUser(string url, long userId)
        {
            Url = url;
            UserId = userId;
        }
#nullable disable
        internal RecentMeUrlUser()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Url);
            writer.WriteInt64(UserId);

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
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "recentMeUrlUser";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new RecentMeUrlUser();
            newClonedObject.Url = Url;
            newClonedObject.UserId = UserId;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not RecentMeUrlUser castedOther)
            {
                return true;
            }

            if (Url != castedOther.Url)
            {
                return true;
            }

            if (UserId != castedOther.UserId)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}