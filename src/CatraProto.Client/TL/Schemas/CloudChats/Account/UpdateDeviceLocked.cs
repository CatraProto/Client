using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class UpdateDeviceLocked : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 954152242; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("period")]
		public int Period { get; set; }

        
        #nullable enable
 public UpdateDeviceLocked (int period)
{
 Period = period;
 
}
#nullable disable
                
        internal UpdateDeviceLocked() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Period);

		}

		public void Deserialize(Reader reader)
		{
			Period = reader.Read<int>();

		}

		public override string ToString()
		{
		    return "account.updateDeviceLocked";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}