using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class UpdateDialogFilter : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Filter = 1 << 0
		}

        public static int ConstructorId { get; } = 450142282;

		public System.Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;
		public int Flags { get; set; }
		public int Id { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase Filter { get; set; }

		public void UpdateFlags() 
		{
			Flags = Filter == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Filter);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Id = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Filter = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase>();
			}


		}
	}
}