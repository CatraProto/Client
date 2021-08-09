using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UserStatusOffline : CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase
	{


        public static int StaticConstructorId { get => 9203775; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("was_online")]
		public int WasOnline { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(WasOnline);

		}

		public override void Deserialize(Reader reader)
		{
			WasOnline = reader.Read<int>();

		}
	}
}