using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class RecentMeUrlUser : CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1188296222; }
        
[Newtonsoft.Json.JsonProperty("url")]
		public sealed override string Url { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public long UserId { get; set; }


        #nullable enable
 public RecentMeUrlUser (string url,long userId)
{
 Url = url;
UserId = userId;
 
}
#nullable disable
        internal RecentMeUrlUser() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Url);
			writer.Write(UserId);

		}

		public override void Deserialize(Reader reader)
		{
			Url = reader.Read<string>();
			UserId = reader.Read<long>();

		}
		
		public override string ToString()
		{
		    return "recentMeUrlUser";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}