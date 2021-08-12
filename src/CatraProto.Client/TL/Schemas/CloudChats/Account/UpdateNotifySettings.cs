using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class UpdateNotifySettings : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -2067899501; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("peer")]
		public InputNotifyPeerBase Peer { get; set; }

[JsonPropertyName("settings")]
		public InputPeerNotifySettingsBase Settings { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Settings);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputNotifyPeerBase>();
			Settings = reader.Read<InputPeerNotifySettingsBase>();
		}

		public override string ToString()
		{
			return "account.updateNotifySettings";
		}
	}
}