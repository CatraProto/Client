using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class JoinGroupCallPresentation : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -873829436; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("call")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

[Newtonsoft.Json.JsonProperty("params")]
		public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Params { get; set; }

        
        #nullable enable
 public JoinGroupCallPresentation (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call,CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase pparams)
{
 Call = call;
Params = pparams;
 
}
#nullable disable
                
        internal JoinGroupCallPresentation() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Call);
			writer.Write(Params);

		}

		public void Deserialize(Reader reader)
		{
			Call = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
			Params = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();

		}
		
		public override string ToString()
		{
		    return "phone.joinGroupCallPresentation";
		}
	}
}