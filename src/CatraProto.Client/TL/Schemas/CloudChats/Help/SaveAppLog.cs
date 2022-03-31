using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class SaveAppLog : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1862465352; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("events")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputAppEventBase> Events { get; set; }

        
        #nullable enable
 public SaveAppLog (IList<CatraProto.Client.TL.Schemas.CloudChats.InputAppEventBase> events)
{
 Events = events;
 
}
#nullable disable
                
        internal SaveAppLog() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Events);

		}

		public void Deserialize(Reader reader)
		{
			Events = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputAppEventBase>();

		}

		public override string ToString()
		{
		    return "help.saveAppLog";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}