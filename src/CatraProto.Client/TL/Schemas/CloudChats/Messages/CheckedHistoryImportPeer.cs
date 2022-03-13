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
		public sealed override string ConfirmText { get; set; }


        #nullable enable
 public CheckedHistoryImportPeer (string confirmText)
{
 ConfirmText = confirmText;
 
}
#nullable disable
        internal CheckedHistoryImportPeer() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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