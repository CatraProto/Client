using System;
using System.Text.Json.Serialization;
using CatraProto.Client.TL.Schemas.CloudChats.Help;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class AuthorizationSignUpRequired : AuthorizationBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			TermsOfService = 1 << 0
		}

        public static int StaticConstructorId { get => 1148485274; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("terms_of_service")]
		public TermsOfServiceBase TermsOfService { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = TermsOfService == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(TermsOfService);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				TermsOfService = reader.Read<TermsOfServiceBase>();
			}


		}
	}
}