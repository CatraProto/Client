using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateUserPhone : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => 88680979; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("user_id")]
		public long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("phone")]
		public string Phone { get; set; }


        #nullable enable
 public UpdateUserPhone (long userId,string phone)
{
 UserId = userId;
Phone = phone;
 
}
#nullable disable
        internal UpdateUserPhone() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(Phone);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<long>();
			Phone = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "updateUserPhone";
		}
	}
}