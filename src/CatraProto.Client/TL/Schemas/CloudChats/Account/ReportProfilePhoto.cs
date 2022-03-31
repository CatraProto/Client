using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class ReportProfilePhoto : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -91437323; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("photo_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase PhotoId { get; set; }

[Newtonsoft.Json.JsonProperty("reason")]
		public CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase Reason { get; set; }

[Newtonsoft.Json.JsonProperty("message")]
		public string Message { get; set; }

        
        #nullable enable
 public ReportProfilePhoto (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase photoId,CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase reason,string message)
{
 Peer = peer;
PhotoId = photoId;
Reason = reason;
Message = message;
 
}
#nullable disable
                
        internal ReportProfilePhoto() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(PhotoId);
			writer.Write(Reason);
			writer.Write(Message);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			PhotoId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase>();
			Reason = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase>();
			Message = reader.Read<string>();

		}

		public override string ToString()
		{
		    return "account.reportProfilePhoto";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}