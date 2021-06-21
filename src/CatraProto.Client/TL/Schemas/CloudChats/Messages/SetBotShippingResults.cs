using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SetBotShippingResults : IMethod
	{
		[Flags]
		public enum FlagsEnum
		{
			Error = 1 << 0,
			ShippingOptions = 1 << 1
		}

		public static int ConstructorId { get; } = -436833542;
		public int Flags { get; set; }
		public long QueryId { get; set; }
		public string Error { get; set; }
		public IList<ShippingOptionBase> ShippingOptions { get; set; }

		public Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
			Flags = Error == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = ShippingOptions == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(QueryId);
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Error);
			}

			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(ShippingOptions);
			}
		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			QueryId = reader.Read<long>();
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				Error = reader.Read<string>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				ShippingOptions = reader.ReadVector<ShippingOptionBase>();
			}
		}
	}
}