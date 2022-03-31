using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateUserPhoto : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -232290676; }
        
[Newtonsoft.Json.JsonProperty("user_id")]
		public long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

[Newtonsoft.Json.JsonProperty("photo")]
		public CatraProto.Client.TL.Schemas.CloudChats.UserProfilePhotoBase Photo { get; set; }

[Newtonsoft.Json.JsonProperty("previous")]
		public bool Previous { get; set; }


        #nullable enable
 public UpdateUserPhoto (long userId,int date,CatraProto.Client.TL.Schemas.CloudChats.UserProfilePhotoBase photo,bool previous)
{
 UserId = userId;
Date = date;
Photo = photo;
Previous = previous;
 
}
#nullable disable
        internal UpdateUserPhoto() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(Date);
			writer.Write(Photo);
			writer.Write(Previous);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<long>();
			Date = reader.Read<int>();
			Photo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.UserProfilePhotoBase>();
			Previous = reader.Read<bool>();

		}
		
		public override string ToString()
		{
		    return "updateUserPhoto";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}