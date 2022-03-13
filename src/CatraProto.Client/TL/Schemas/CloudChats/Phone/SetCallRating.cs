using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class SetCallRating : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			UserInitiative = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1508562471; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("user_initiative")]
		public bool UserInitiative { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("rating")]
		public int Rating { get; set; }

[Newtonsoft.Json.JsonProperty("comment")]
		public string Comment { get; set; }

        
        #nullable enable
 public SetCallRating (CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer,int rating,string comment)
{
 Peer = peer;
Rating = rating;
Comment = comment;
 
}
#nullable disable
                
        internal SetCallRating() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = UserInitiative ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(Rating);
			writer.Write(Comment);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			UserInitiative = FlagsHelper.IsFlagSet(Flags, 0);
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase>();
			Rating = reader.Read<int>();
			Comment = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "phone.setCallRating";
		}
	}
}