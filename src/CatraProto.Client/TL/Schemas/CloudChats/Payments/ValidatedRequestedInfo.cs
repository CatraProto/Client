using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

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

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -784000893; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

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
            var newClonedObject = new ValidatedRequestedInfo();
            newClonedObject.Flags = Flags;
            newClonedObject.Id = Id;
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