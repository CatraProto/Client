using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class WebPageNotModified : WebPageBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			CachedPageViews = 1 << 0
		}

        public static int ConstructorId { get; } = 1930545681;
		public int Flags { get; set; }
		public int? CachedPageViews { get; set; }

		public override void UpdateFlags() 
		{
			Flags = CachedPageViews == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(CachedPageViews.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				CachedPageViews = reader.Read<int>();
			}


		}
	}
}