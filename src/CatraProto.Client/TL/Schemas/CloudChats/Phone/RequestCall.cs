using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class RequestCall : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Video = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1124046573; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("video")]
		public bool Video { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }

[Newtonsoft.Json.JsonProperty("random_id")]
		public int RandomId { get; set; }

[Newtonsoft.Json.JsonProperty("g_a_hash")]
		public byte[] GAHash { get; set; }

[Newtonsoft.Json.JsonProperty("protocol")]
		public CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase Protocol { get; set; }

        
        #nullable enable
 public RequestCall (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId,int randomId,byte[] gAHash,CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase protocol)
{
 UserId = userId;
RandomId = randomId;
GAHash = gAHash;
Protocol = protocol;
 
}
#nullable disable
                
        internal RequestCall() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = Video ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(UserId);
			writer.Write(RandomId);
			writer.Write(GAHash);
			writer.Write(Protocol);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Video = FlagsHelper.IsFlagSet(Flags, 0);
			UserId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
			RandomId = reader.Read<int>();
			GAHash = reader.Read<byte[]>();
			Protocol = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase>();

		}

		public override string ToString()
		{
		    return "phone.requestCall";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}