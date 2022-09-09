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
    public partial class RecentMeUrlStickerSet : CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1140172836; }

        [Newtonsoft.Json.JsonProperty("url")] public sealed override string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("set")] public CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase Set { get; set; }


#nullable enable
        public RecentMeUrlStickerSet(string url, CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase set)
        {
            Url = url;
            Set = set;
        }
#nullable disable
        internal RecentMeUrlStickerSet()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Url);
            var checkset = writer.WriteObject(Set);
            if (checkset.IsError)
            {
                return checkset;
            }

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
            var tryset = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase>();
            if (tryset.IsError)
            {
                return ReadResult<IObject>.Move(tryset);
            }

            Set = tryset.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "recentMeUrlStickerSet";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new RecentMeUrlStickerSet();
            newClonedObject.Url = Url;
            var cloneSet = (CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase?)Set.Clone();
            if (cloneSet is null)
            {
                return null;
            }

            newClonedObject.Set = cloneSet;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not RecentMeUrlStickerSet castedOther)
            {
                return true;
            }

            if (Url != castedOther.Url)
            {
                return true;
            }

            if (Set.Compare(castedOther.Set))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}