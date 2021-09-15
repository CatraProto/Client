using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class BoolFalse : IObject
	{


        public static int StaticConstructorId { get => -1132882121; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);

		}

		public void Deserialize(Reader reader)
		{

		}
				
		public override string ToString()
		{
		    return "boolFalse";
		}
	}
}