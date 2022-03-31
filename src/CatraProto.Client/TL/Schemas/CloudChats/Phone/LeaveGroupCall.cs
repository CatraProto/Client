using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class LeaveGroupCall : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1342404601; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("call")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

[Newtonsoft.Json.JsonProperty("source")]
		public int Source { get; set; }

        
        #nullable enable
 public LeaveGroupCall (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call,int source)
{
 Call = call;
Source = source;
 
}
#nullable disable
                
        internal LeaveGroupCall() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Call);
			writer.Write(Source);

		}

		public void Deserialize(Reader reader)
		{
			Call = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
			Source = reader.Read<int>();

		}

		public override string ToString()
		{
		    return "phone.leaveGroupCall";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}