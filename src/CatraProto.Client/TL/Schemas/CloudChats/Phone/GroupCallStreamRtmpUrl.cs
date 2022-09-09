using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class GroupCallStreamRtmpUrl : CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupCallStreamRtmpUrlBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 767505458; }

        [Newtonsoft.Json.JsonProperty("url")] public sealed override string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("key")] public sealed override string Key { get; set; }


#nullable enable
        public GroupCallStreamRtmpUrl(string url, string key)
        {
            Url = url;
            Key = key;
        }
#nullable disable
        internal GroupCallStreamRtmpUrl()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Url);

            writer.WriteString(Key);

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
            var trykey = reader.ReadString();
            if (trykey.IsError)
            {
                return ReadResult<IObject>.Move(trykey);
            }

            Key = trykey.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "phone.groupCallStreamRtmpUrl";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new GroupCallStreamRtmpUrl();
            newClonedObject.Url = Url;
            newClonedObject.Key = Key;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not GroupCallStreamRtmpUrl castedOther)
            {
                return true;
            }

            if (Url != castedOther.Url)
            {
                return true;
            }

            if (Key != castedOther.Key)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}