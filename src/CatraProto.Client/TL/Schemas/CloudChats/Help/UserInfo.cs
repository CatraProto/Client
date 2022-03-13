using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class UserInfo : CatraProto.Client.TL.Schemas.CloudChats.Help.UserInfoBase
	{


        public static int StaticConstructorId { get => 32192344; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("message")]
		public string Message { get; set; }

[Newtonsoft.Json.JsonProperty("entities")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

[Newtonsoft.Json.JsonProperty("author")]
		public string Author { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }


        #nullable enable
 public UserInfo (string message,IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> entities,string author,int date)
{
 Message = message;
Entities = entities;
Author = author;
Date = date;
 
}
#nullable disable
        internal UserInfo() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Message);
			writer.Write(Entities);
			writer.Write(Author);
			writer.Write(Date);

		}

		public override void Deserialize(Reader reader)
		{
			Message = reader.Read<string>();
			Entities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();
			Author = reader.Read<string>();
			Date = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "help.userInfo";
		}
	}
}