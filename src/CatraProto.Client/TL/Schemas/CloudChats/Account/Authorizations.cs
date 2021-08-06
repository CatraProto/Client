using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class Authorizations : CatraProto.Client.TL.Schemas.CloudChats.Account.AuthorizationsBase
	{


        public static int StaticConstructorId { get => 307276766; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("Authorizations_")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.AuthorizationBase> Authorizations_ { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Authorizations_);

		}

		public override void Deserialize(Reader reader)
		{
			Authorizations_ = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.AuthorizationBase>();

		}
	}
}