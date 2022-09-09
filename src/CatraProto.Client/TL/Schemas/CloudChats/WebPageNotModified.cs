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
    public partial class WebPageNotModified : CatraProto.Client.TL.Schemas.CloudChats.WebPageBase
    {
        [Flags]
        public enum FlagsEnum
        {
            CachedPageViews = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1930545681; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("cached_page_views")]
        public int? CachedPageViews { get; set; }


        public WebPageNotModified()
        {
        }

        public override void UpdateFlags()
        {
            Flags = CachedPageViews == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(CachedPageViews.Value);
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
                var trycachedPageViews = reader.ReadInt32();
                if (trycachedPageViews.IsError)
                {
                    return ReadResult<IObject>.Move(trycachedPageViews);
                }

                CachedPageViews = trycachedPageViews.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "webPageNotModified";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new WebPageNotModified();
            newClonedObject.Flags = Flags;
            newClonedObject.CachedPageViews = CachedPageViews;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not WebPageNotModified castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (CachedPageViews != castedOther.CachedPageViews)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}