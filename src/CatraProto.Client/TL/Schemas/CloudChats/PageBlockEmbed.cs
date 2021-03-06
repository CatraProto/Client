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
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PageBlockEmbed : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
    {
        [Flags]
        public enum FlagsEnum
        {
            FullWidth = 1 << 0,
            AllowScrolling = 1 << 3,
            Url = 1 << 1,
            Html = 1 << 2,
            PosterPhotoId = 1 << 4,
            W = 1 << 5,
            H = 1 << 5
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1468953147; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("full_width")]
        public bool FullWidth { get; set; }

        [Newtonsoft.Json.JsonProperty("allow_scrolling")]
        public bool AllowScrolling { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("url")]
        public string Url { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("html")]
        public string Html { get; set; }

        [Newtonsoft.Json.JsonProperty("poster_photo_id")]
        public long? PosterPhotoId { get; set; }

        [Newtonsoft.Json.JsonProperty("w")]
        public int? W { get; set; }

        [Newtonsoft.Json.JsonProperty("h")]
        public int? H { get; set; }

        [Newtonsoft.Json.JsonProperty("caption")]
        public CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase Caption { get; set; }


#nullable enable
        public PageBlockEmbed(CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase caption)
        {
            Caption = caption;

        }
#nullable disable
        internal PageBlockEmbed()
        {
        }

        public override void UpdateFlags()
        {
            Flags = FullWidth ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = AllowScrolling ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = Url == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = Html == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = PosterPhotoId == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
            Flags = W == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
            Flags = H == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {

                writer.WriteString(Url);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {

                writer.WriteString(Html);
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.WriteInt64(PosterPhotoId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                writer.WriteInt32(W.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                writer.WriteInt32(H.Value);
            }

            var checkcaption = writer.WriteObject(Caption);
            if (checkcaption.IsError)
            {
                return checkcaption;
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
            FullWidth = FlagsHelper.IsFlagSet(Flags, 0);
            AllowScrolling = FlagsHelper.IsFlagSet(Flags, 3);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryurl = reader.ReadString();
                if (tryurl.IsError)
                {
                    return ReadResult<IObject>.Move(tryurl);
                }
                Url = tryurl.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryhtml = reader.ReadString();
                if (tryhtml.IsError)
                {
                    return ReadResult<IObject>.Move(tryhtml);
                }
                Html = tryhtml.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var tryposterPhotoId = reader.ReadInt64();
                if (tryposterPhotoId.IsError)
                {
                    return ReadResult<IObject>.Move(tryposterPhotoId);
                }
                PosterPhotoId = tryposterPhotoId.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                var tryw = reader.ReadInt32();
                if (tryw.IsError)
                {
                    return ReadResult<IObject>.Move(tryw);
                }
                W = tryw.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                var tryh = reader.ReadInt32();
                if (tryh.IsError)
                {
                    return ReadResult<IObject>.Move(tryh);
                }
                H = tryh.Value;
            }

            var trycaption = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase>();
            if (trycaption.IsError)
            {
                return ReadResult<IObject>.Move(trycaption);
            }
            Caption = trycaption.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "pageBlockEmbed";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PageBlockEmbed
            {
                Flags = Flags,
                FullWidth = FullWidth,
                AllowScrolling = AllowScrolling,
                Url = Url,
                Html = Html,
                PosterPhotoId = PosterPhotoId,
                W = W,
                H = H
            };
            var cloneCaption = (CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase?)Caption.Clone();
            if (cloneCaption is null)
            {
                return null;
            }
            newClonedObject.Caption = cloneCaption;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not PageBlockEmbed castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (FullWidth != castedOther.FullWidth)
            {
                return true;
            }
            if (AllowScrolling != castedOther.AllowScrolling)
            {
                return true;
            }
            if (Url != castedOther.Url)
            {
                return true;
            }
            if (Html != castedOther.Html)
            {
                return true;
            }
            if (PosterPhotoId != castedOther.PosterPhotoId)
            {
                return true;
            }
            if (W != castedOther.W)
            {
                return true;
            }
            if (H != castedOther.H)
            {
                return true;
            }
            if (Caption.Compare(castedOther.Caption))
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}