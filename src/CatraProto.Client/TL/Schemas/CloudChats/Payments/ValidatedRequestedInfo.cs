using System;
using System.Collections.Generic;
using CatraProto.TL;

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

        public static int StaticConstructorId
        {
            get => -784000893;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("shipping_options")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.ShippingOptionBase> ShippingOptions { get; set; }


        public ValidatedRequestedInfo()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Id == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = ShippingOptions == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(Id);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(ShippingOptions);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                Id = reader.Read<string>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                ShippingOptions = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ShippingOptionBase>();
            }
        }

        public override string ToString()
        {
            return "payments.validatedRequestedInfo";
        }
    }
}