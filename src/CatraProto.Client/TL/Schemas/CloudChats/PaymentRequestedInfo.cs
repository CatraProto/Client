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
    public partial class PaymentRequestedInfo : CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Name = 1 << 0,
            Phone = 1 << 1,
            Email = 1 << 2,
            ShippingAddress = 1 << 3
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1868808300; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("name")]
        public sealed override string Name { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("phone")]
        public sealed override string Phone { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("email")]
        public sealed override string Email { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("shipping_address")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PostAddressBase ShippingAddress { get; set; }


        public PaymentRequestedInfo()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Name == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Phone == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = Email == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = ShippingAddress == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteString(Name);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteString(Phone);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteString(Email);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var checkshippingAddress = writer.WriteObject(ShippingAddress);
                if (checkshippingAddress.IsError)
                {
                    return checkshippingAddress;
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
                var tryname = reader.ReadString();
                if (tryname.IsError)
                {
                    return ReadResult<IObject>.Move(tryname);
                }

                Name = tryname.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryphone = reader.ReadString();
                if (tryphone.IsError)
                {
                    return ReadResult<IObject>.Move(tryphone);
                }

                Phone = tryphone.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryemail = reader.ReadString();
                if (tryemail.IsError)
                {
                    return ReadResult<IObject>.Move(tryemail);
                }

                Email = tryemail.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var tryshippingAddress = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PostAddressBase>();
                if (tryshippingAddress.IsError)
                {
                    return ReadResult<IObject>.Move(tryshippingAddress);
                }

                ShippingAddress = tryshippingAddress.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "paymentRequestedInfo";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PaymentRequestedInfo();
            newClonedObject.Flags = Flags;
            newClonedObject.Name = Name;
            newClonedObject.Phone = Phone;
            newClonedObject.Email = Email;
            if (ShippingAddress is not null)
            {
                var cloneShippingAddress = (CatraProto.Client.TL.Schemas.CloudChats.PostAddressBase?)ShippingAddress.Clone();
                if (cloneShippingAddress is null)
                {
                    return null;
                }

                newClonedObject.ShippingAddress = cloneShippingAddress;
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PaymentRequestedInfo castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Name != castedOther.Name)
            {
                return true;
            }

            if (Phone != castedOther.Phone)
            {
                return true;
            }

            if (Email != castedOther.Email)
            {
                return true;
            }

            if (ShippingAddress is null && castedOther.ShippingAddress is not null || ShippingAddress is not null && castedOther.ShippingAddress is null)
            {
                return true;
            }

            if (ShippingAddress is not null && castedOther.ShippingAddress is not null && ShippingAddress.Compare(castedOther.ShippingAddress))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}