using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPaymentCredentials : CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Save = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 873977640; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("save")]
		public bool Save { get; set; }

[Newtonsoft.Json.JsonProperty("data")]
		public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Data { get; set; }


        #nullable enable
 public InputPaymentCredentials (CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase data)
{
 Data = data;
 
}
#nullable disable
        internal InputPaymentCredentials() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Save ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Data);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Save = FlagsHelper.IsFlagSet(Flags, 0);
			Data = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();

		}
		
		public override string ToString()
		{
		    return "inputPaymentCredentials";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}