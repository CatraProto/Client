using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SendEncryptedFile : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Silent = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1431914525; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("silent")]
		public bool Silent { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("random_id")]
		public long RandomId { get; set; }

[Newtonsoft.Json.JsonProperty("data")]
		public byte[] Data { get; set; }

[Newtonsoft.Json.JsonProperty("file")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBase File { get; set; }


		public void UpdateFlags() 
		{
			Flags = Silent ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(RandomId);
			writer.Write(Data);
			writer.Write(File);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Silent = FlagsHelper.IsFlagSet(Flags, 0);
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase>();
			RandomId = reader.Read<long>();
			Data = reader.Read<byte[]>();
			File = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBase>();

		}
		
		public override string ToString()
		{
		    return "messages.sendEncryptedFile";
		}
	}
}