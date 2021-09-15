using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
	public partial class DifferenceSlice : CatraProto.Client.TL.Schemas.CloudChats.Updates.DifferenceBase
	{


        public static int StaticConstructorId { get => -1459938943; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("new_messages")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> NewMessages { get; set; }

[Newtonsoft.Json.JsonProperty("new_encrypted_messages")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.EncryptedMessageBase> NewEncryptedMessages { get; set; }

[Newtonsoft.Json.JsonProperty("other_updates")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase> OtherUpdates { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

[Newtonsoft.Json.JsonProperty("intermediate_state")]
		public CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase IntermediateState { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(NewMessages);
			writer.Write(NewEncryptedMessages);
			writer.Write(OtherUpdates);
			writer.Write(Chats);
			writer.Write(Users);
			writer.Write(IntermediateState);

		}

		public override void Deserialize(Reader reader)
		{
			NewMessages = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
			NewEncryptedMessages = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.EncryptedMessageBase>();
			OtherUpdates = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase>();
			Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
			IntermediateState = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase>();

		}
				
		public override string ToString()
		{
		    return "updates.differenceSlice";
		}
	}
}