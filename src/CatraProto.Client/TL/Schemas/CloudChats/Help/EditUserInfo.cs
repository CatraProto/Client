using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class EditUserInfo : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 1723407216; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Help.UserInfoBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("user_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }

[JsonPropertyName("message")]
		public string Message { get; set; }

[JsonPropertyName("entities")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(Message);
			writer.Write(Entities);

		}

		public void Deserialize(Reader reader)
		{
			UserId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
			Message = reader.Read<string>();
			Entities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();

		}
	}
}