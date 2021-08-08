using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class PhoneCall : PhoneCallBase
	{


        public static int StaticConstructorId { get => -326966976; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("PhoneCall_")]
		public override CloudChats.PhoneCallBase PhoneCall_ { get; set; }

[JsonPropertyName("users")]
		public override IList<UserBase> Users { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PhoneCall_);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			PhoneCall_ = reader.Read<CloudChats.PhoneCallBase>();
			Users = reader.ReadVector<UserBase>();

		}
	}
}