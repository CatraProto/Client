using System;
using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class Invoice : InvoiceBase
	{
		[Flags]
		public enum FlagsEnum
		{
			Test = 1 << 0,
			NameRequested = 1 << 1,
			PhoneRequested = 1 << 2,
			EmailRequested = 1 << 3,
			ShippingAddressRequested = 1 << 4,
			Flexible = 1 << 5,
			PhoneToProvider = 1 << 6,
			EmailToProvider = 1 << 7
		}

		public static int ConstructorId { get; } = -1022713000;
		public int Flags { get; set; }
		public override bool Test { get; set; }
		public override bool NameRequested { get; set; }
		public override bool PhoneRequested { get; set; }
		public override bool EmailRequested { get; set; }
		public override bool ShippingAddressRequested { get; set; }
		public override bool Flexible { get; set; }
		public override bool PhoneToProvider { get; set; }
		public override bool EmailToProvider { get; set; }
		public override string Currency { get; set; }
		public override IList<LabeledPriceBase> Prices { get; set; }

		public override void UpdateFlags()
		{
			Flags = Test ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = NameRequested ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = PhoneRequested ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = EmailRequested ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = ShippingAddressRequested ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
			Flags = Flexible ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = PhoneToProvider ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
			Flags = EmailToProvider ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Currency);
			writer.Write(Prices);
		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Test = FlagsHelper.IsFlagSet(Flags, 0);
			NameRequested = FlagsHelper.IsFlagSet(Flags, 1);
			PhoneRequested = FlagsHelper.IsFlagSet(Flags, 2);
			EmailRequested = FlagsHelper.IsFlagSet(Flags, 3);
			ShippingAddressRequested = FlagsHelper.IsFlagSet(Flags, 4);
			Flexible = FlagsHelper.IsFlagSet(Flags, 5);
			PhoneToProvider = FlagsHelper.IsFlagSet(Flags, 6);
			EmailToProvider = FlagsHelper.IsFlagSet(Flags, 7);
			Currency = reader.Read<string>();
			Prices = reader.ReadVector<LabeledPriceBase>();
		}
	}
}