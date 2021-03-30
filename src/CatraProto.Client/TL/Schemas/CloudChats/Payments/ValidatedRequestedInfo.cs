using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
	public partial class ValidatedRequestedInfo : ValidatedRequestedInfoBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Id = 1 << 0,
			ShippingOptions = 1 << 1
		}

        public static int ConstructorId { get; } = -784000893;
		public int Flags { get; set; }
		public override string Id { get; set; }
		public override IList<ShippingOptionBase> ShippingOptions { get; set; }

		public override void UpdateFlags() 
		{
			Flags = Id == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = ShippingOptions == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Id);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(ShippingOptions);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Id = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				ShippingOptions = reader.ReadVector<ShippingOptionBase>();
			}


		}
	}
}