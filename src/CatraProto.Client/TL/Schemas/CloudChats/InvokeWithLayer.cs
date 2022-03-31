using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InvokeWithLayer : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -627372787; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(IObject);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("layer")]
		public int Layer { get; set; }

[Newtonsoft.Json.JsonProperty("query")]
		public IObject Query { get; set; }

        
        #nullable enable
 public InvokeWithLayer (int layer,IObject query)
{
 Layer = layer;
Query = query;
 
}
#nullable disable
                
        internal InvokeWithLayer() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Layer);
			writer.Write(Query);

		}

		public void Deserialize(Reader reader)
		{
			Layer = reader.Read<int>();
			Query = reader.Read<IObject>();

		}

		public override string ToString()
		{
		    return "invokeWithLayer";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}