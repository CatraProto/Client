/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

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

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1930545681; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

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
            var newClonedObject = new WebPageNotModified
            {
                Flags = Flags,
                CachedPageViews = CachedPageViews
            };
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