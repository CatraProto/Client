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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public partial class ValidatedRequestedInfo : CatraProto.Client.TL.Schemas.CloudChats.Payments.ValidatedRequestedInfoBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Id = 1 << 0,
            ShippingOptions = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -784000893; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("id")]
        public sealed override string Id { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("shipping_options")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ShippingOptionBase> ShippingOptions { get; set; }



        public ValidatedRequestedInfo()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Id == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = ShippingOptions == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {

                writer.WriteString(Id);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checkshippingOptions = writer.WriteVector(ShippingOptions, false);
                if (checkshippingOptions.IsError)
                {
                    return checkshippingOptions;
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
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryid = reader.ReadString();
                if (tryid.IsError)
                {
                    return ReadResult<IObject>.Move(tryid);
                }
                Id = tryid.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryshippingOptions = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ShippingOptionBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
                if (tryshippingOptions.IsError)
                {
                    return ReadResult<IObject>.Move(tryshippingOptions);
                }
                ShippingOptions = tryshippingOptions.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "payments.validatedRequestedInfo";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ValidatedRequestedInfo
            {
                Flags = Flags,
                Id = Id
            };
            if (ShippingOptions is not null)
            {
                newClonedObject.ShippingOptions = new List<CatraProto.Client.TL.Schemas.CloudChats.ShippingOptionBase>();
                foreach (var shippingOptions in ShippingOptions)
                {
                    var cloneshippingOptions = (CatraProto.Client.TL.Schemas.CloudChats.ShippingOptionBase?)shippingOptions.Clone();
                    if (cloneshippingOptions is null)
                    {
                        return null;
                    }
                    newClonedObject.ShippingOptions.Add(cloneshippingOptions);
                }
            }
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not ValidatedRequestedInfo castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (Id != castedOther.Id)
            {
                return true;
            }
            if (ShippingOptions is null && castedOther.ShippingOptions is not null || ShippingOptions is not null && castedOther.ShippingOptions is null)
            {
                return true;
            }
            if (ShippingOptions is not null && castedOther.ShippingOptions is not null)
            {

                var shippingOptionssize = castedOther.ShippingOptions.Count;
                if (shippingOptionssize != ShippingOptions.Count)
                {
                    return true;
                }
                for (var i = 0; i < shippingOptionssize; i++)
                {
                    if (castedOther.ShippingOptions[i].Compare(ShippingOptions[i]))
                    {
                        return true;
                    }
                }
            }
            return false;

        }

#nullable disable
    }
}