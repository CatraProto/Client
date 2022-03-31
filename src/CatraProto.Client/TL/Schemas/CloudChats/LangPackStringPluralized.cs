using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class LangPackStringPluralized : CatraProto.Client.TL.Schemas.CloudChats.LangPackStringBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			ZeroValue = 1 << 0,
			OneValue = 1 << 1,
			TwoValue = 1 << 2,
			FewValue = 1 << 3,
			ManyValue = 1 << 4
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1816636575; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("key")]
		public sealed override string Key { get; set; }

[Newtonsoft.Json.JsonProperty("zero_value")]
		public string ZeroValue { get; set; }

[Newtonsoft.Json.JsonProperty("one_value")]
		public string OneValue { get; set; }

[Newtonsoft.Json.JsonProperty("two_value")]
		public string TwoValue { get; set; }

[Newtonsoft.Json.JsonProperty("few_value")]
		public string FewValue { get; set; }

[Newtonsoft.Json.JsonProperty("many_value")]
		public string ManyValue { get; set; }

[Newtonsoft.Json.JsonProperty("other_value")]
		public string OtherValue { get; set; }


        #nullable enable
 public LangPackStringPluralized (string key,string otherValue)
{
 Key = key;
OtherValue = otherValue;
 
}
#nullable disable
        internal LangPackStringPluralized() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = ZeroValue == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = OneValue == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = TwoValue == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = FewValue == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = ManyValue == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Key);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(ZeroValue);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(OneValue);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(TwoValue);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(FewValue);
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(ManyValue);
			}

			writer.Write(OtherValue);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Key = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				ZeroValue = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				OneValue = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				TwoValue = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				FewValue = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				ManyValue = reader.Read<string>();
			}

			OtherValue = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "langPackStringPluralized";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}