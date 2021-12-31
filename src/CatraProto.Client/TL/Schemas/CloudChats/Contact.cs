using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class Contact : CatraProto.Client.TL.Schemas.CloudChats.ContactBase
	{


        public static int StaticConstructorId { get => 341499403; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("user_id")]
		public override long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("mutual")]
		public override bool Mutual { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(Mutual);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<long>();
			Mutual = reader.Read<bool>();

		}
				
		public override string ToString()
		{
		    return "contact";
		}
	}
}