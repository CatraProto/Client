using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PaymentRequestedInfo : PaymentRequestedInfoBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Name = 1 << 0,
			Phone = 1 << 1,
			Email = 1 << 2,
			ShippingAddress = 1 << 3
		}

        public static int ConstructorId { get; } = -1868808300;
		public int Flags { get; set; }
		public override string Name { get; set; }
		public override string Phone { get; set; }
		public override string Email { get; set; }
		public override PostAddressBase ShippingAddress { get; set; }

		public override void UpdateFlags() 
		{
			Flags = Name == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Phone == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = Email == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = ShippingAddress == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Name);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Phone);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Email);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(ShippingAddress);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Name = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Phone = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Email = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				ShippingAddress = reader.Read<PostAddressBase>();
			}


		}
	}
}