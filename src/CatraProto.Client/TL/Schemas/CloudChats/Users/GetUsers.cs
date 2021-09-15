using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Users
{
	public partial class GetUsers : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 227648840; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UserBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = true;

[Newtonsoft.Json.JsonProperty("id")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase> Id { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);

		}

		public void Deserialize(Reader reader)
		{
			Id = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();

		}
		
		public override string ToString()
		{
		    return "users.getUsers";
		}
	}
}