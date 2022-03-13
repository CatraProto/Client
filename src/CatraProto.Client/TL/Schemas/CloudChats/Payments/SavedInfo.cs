using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
	public partial class SavedInfo : CatraProto.Client.TL.Schemas.CloudChats.Payments.SavedInfoBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			HasSavedCredentials = 1 << 1,
			SavedInfoField = 1 << 0
		}

        public static int StaticConstructorId { get => -74456004; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("has_saved_credentials")]
		public sealed override bool HasSavedCredentials { get; set; }

[Newtonsoft.Json.JsonProperty("saved_info")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase SavedInfoField { get; set; }


        
        public SavedInfo() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = HasSavedCredentials ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = SavedInfoField == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(SavedInfoField);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			HasSavedCredentials = FlagsHelper.IsFlagSet(Flags, 1);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				SavedInfoField = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase>();
			}


		}
				
		public override string ToString()
		{
		    return "payments.savedInfo";
		}
	}
}