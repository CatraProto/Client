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
    public partial class BotInlineMessageMediaGeo : CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Heading = 1 << 0,
            Period = 1 << 1,
            ProximityNotificationRadius = 1 << 3,
            ReplyMarkup = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 85477117; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("geo")]
        public CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase Geo { get; set; }

        [Newtonsoft.Json.JsonProperty("heading")]
        public int? Heading { get; set; }

        [Newtonsoft.Json.JsonProperty("period")]
        public int? Period { get; set; }

        [Newtonsoft.Json.JsonProperty("proximity_notification_radius")]
        public int? ProximityNotificationRadius { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("reply_markup")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase ReplyMarkup { get; set; }


#nullable enable
        public BotInlineMessageMediaGeo(CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase geo)
        {
            Geo = geo;

        }
#nullable disable
        internal BotInlineMessageMediaGeo()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Heading == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Period == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = ProximityNotificationRadius == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = ReplyMarkup == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkgeo = writer.WriteObject(Geo);
            if (checkgeo.IsError)
            {
                return checkgeo;
            }
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(Heading.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt32(Period.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.WriteInt32(ProximityNotificationRadius.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var checkreplyMarkup = writer.WriteObject(ReplyMarkup);
                if (checkreplyMarkup.IsError)
                {
                    return checkreplyMarkup;
                }
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
            var trygeo = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase>();
            if (trygeo.IsError)
            {
                return ReadResult<IObject>.Move(trygeo);
            }
            Geo = trygeo.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryheading = reader.ReadInt32();
                if (tryheading.IsError)
                {
                    return ReadResult<IObject>.Move(tryheading);
                }
                Heading = tryheading.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryperiod = reader.ReadInt32();
                if (tryperiod.IsError)
                {
                    return ReadResult<IObject>.Move(tryperiod);
                }
                Period = tryperiod.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var tryproximityNotificationRadius = reader.ReadInt32();
                if (tryproximityNotificationRadius.IsError)
                {
                    return ReadResult<IObject>.Move(tryproximityNotificationRadius);
                }
                ProximityNotificationRadius = tryproximityNotificationRadius.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryreplyMarkup = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase>();
                if (tryreplyMarkup.IsError)
                {
                    return ReadResult<IObject>.Move(tryreplyMarkup);
                }
                ReplyMarkup = tryreplyMarkup.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "botInlineMessageMediaGeo";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new BotInlineMessageMediaGeo
            {
                Flags = Flags
            };
            var cloneGeo = (CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase?)Geo.Clone();
            if (cloneGeo is null)
            {
                return null;
            }
            newClonedObject.Geo = cloneGeo;
            newClonedObject.Heading = Heading;
            newClonedObject.Period = Period;
            newClonedObject.ProximityNotificationRadius = ProximityNotificationRadius;
            if (ReplyMarkup is not null)
            {
                var cloneReplyMarkup = (CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase?)ReplyMarkup.Clone();
                if (cloneReplyMarkup is null)
                {
                    return null;
                }
                newClonedObject.ReplyMarkup = cloneReplyMarkup;
            }
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not BotInlineMessageMediaGeo castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (Geo.Compare(castedOther.Geo))
            {
                return true;
            }
            if (Heading != castedOther.Heading)
            {
                return true;
            }
            if (Period != castedOther.Period)
            {
                return true;
            }
            if (ProximityNotificationRadius != castedOther.ProximityNotificationRadius)
            {
                return true;
            }
            if (ReplyMarkup is null && castedOther.ReplyMarkup is not null || ReplyMarkup is not null && castedOther.ReplyMarkup is null)
            {
                return true;
            }
            if (ReplyMarkup is not null && castedOther.ReplyMarkup is not null && ReplyMarkup.Compare(castedOther.ReplyMarkup))
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}