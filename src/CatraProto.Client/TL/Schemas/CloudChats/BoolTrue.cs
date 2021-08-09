using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class BoolTrue : IObject
	{


        public static int StaticConstructorId { get => -1720552011; }
        [JsonIgnore]
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
	}
}