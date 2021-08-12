using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class Authorizations : AuthorizationsBase
	{


        public static int StaticConstructorId { get => 307276766; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("Authorizations_")]
		public override IList<AuthorizationBase> Authorizations_ { get; set; }

        
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
			Authorizations_ = reader.ReadVector<AuthorizationBase>();
		}

		public override string ToString()
		{
			return "account.authorizations";
		}
	}
}