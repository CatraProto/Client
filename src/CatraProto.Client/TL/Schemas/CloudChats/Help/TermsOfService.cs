using System;
using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class TermsOfService : TermsOfServiceBase
	{
		[Flags]
		public enum FlagsEnum
		{
			Popup = 1 << 0,
			MinAgeConfirm = 1 << 1
		}

		public static int ConstructorId { get; } = 2013922064;
		public int Flags { get; set; }
		public override bool Popup { get; set; }
		public override DataJSONBase Id { get; set; }
		public override string Text { get; set; }
		public override IList<MessageEntityBase> Entities { get; set; }
		public override int? MinAgeConfirm { get; set; }

		public override void UpdateFlags()
		{
			Flags = Popup ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = MinAgeConfirm == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(Text);
			writer.Write(Entities);
			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(MinAgeConfirm.Value);
			}
		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Popup = FlagsHelper.IsFlagSet(Flags, 0);
			Id = reader.Read<DataJSONBase>();
			Text = reader.Read<string>();
			Entities = reader.ReadVector<MessageEntityBase>();
			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				MinAgeConfirm = reader.Read<int>();
			}
		}
	}
}