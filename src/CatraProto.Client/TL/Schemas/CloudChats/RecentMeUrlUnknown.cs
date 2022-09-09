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
    public partial class RecentMeUrlUnknown : CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1189204285; }

        [Newtonsoft.Json.JsonProperty("url")] public sealed override string Url { get; set; }


#nullable enable
        public RecentMeUrlUnknown(string url)
        {
            Url = url;
        }
#nullable disable
        internal RecentMeUrlUnknown()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Url);

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
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "recentMeUrlUnknown";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new RecentMeUrlUnknown();
            newClonedObject.Url = Url;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not RecentMeUrlUnknown castedOther)
            {
                return true;
            }

            if (Url != castedOther.Url)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}