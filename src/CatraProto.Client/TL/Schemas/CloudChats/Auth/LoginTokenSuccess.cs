using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class LoginTokenSuccess : LoginTokenBase
	{


        public static int StaticConstructorId { get => 957176926; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("authorization")]
		public AuthorizationBase Authorization { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Authorization);

		}

		public override void Deserialize(Reader reader)
		{
			Authorization = reader.Read<AuthorizationBase>();

		}
	}
}