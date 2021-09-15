using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Users
{
	public partial class SetSecureValueErrors : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -1865902923; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase Id { get; set; }

[Newtonsoft.Json.JsonProperty("errors")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase> Errors { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Errors);

		}

		public void Deserialize(Reader reader)
		{
			Id = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
			Errors = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase>();

		}
		
		public override string ToString()
		{
		    return "users.setSecureValueErrors";
		}
	}
}