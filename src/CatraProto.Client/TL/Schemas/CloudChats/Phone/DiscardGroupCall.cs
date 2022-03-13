using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class DiscardGroupCall : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 2054648117; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("call")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

        
        #nullable enable
 public DiscardGroupCall (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call)
{
 Call = call;
 
}
#nullable disable
                
        internal DiscardGroupCall() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Call);

		}

		public void Deserialize(Reader reader)
		{
			Call = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();

		}
		
		public override string ToString()
		{
		    return "phone.discardGroupCall";
		}
	}
}