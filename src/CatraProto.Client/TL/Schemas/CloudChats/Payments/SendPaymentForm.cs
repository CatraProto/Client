using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
	public partial class SendPaymentForm : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			RequestedInfoId = 1 << 0,
			ShippingOptionId = 1 << 1
		}

        public static int ConstructorId { get; } = 730364339;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Payments.SendPaymentForm);
		public bool IsVector { get; init; } = false;
		public int Flags { get; set; }
		public int MsgId { get; set; }
		public string RequestedInfoId { get; set; }
		public string ShippingOptionId { get; set; }
		public InputPaymentCredentialsBase Credentials { get; set; }

		public void UpdateFlags() 
		{
			Flags = RequestedInfoId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = ShippingOptionId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(MsgId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(RequestedInfoId);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(ShippingOptionId);
			}

			writer.Write(Credentials);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			MsgId = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				RequestedInfoId = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				ShippingOptionId = reader.Read<string>();
			}

			Credentials = reader.Read<InputPaymentCredentialsBase>();

		}
	}
}