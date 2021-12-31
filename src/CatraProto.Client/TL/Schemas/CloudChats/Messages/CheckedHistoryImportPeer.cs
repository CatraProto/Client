using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class CheckedHistoryImportPeer : CatraProto.Client.TL.Schemas.CloudChats.Messages.CheckedHistoryImportPeerBase
	{


        public static int StaticConstructorId { get => -1571952873; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("confirm_text")]
		public override string ConfirmText { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ConfirmText);

		}

		public override void Deserialize(Reader reader)
		{
			ConfirmText = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "messages.checkedHistoryImportPeer";
		}
	}
}