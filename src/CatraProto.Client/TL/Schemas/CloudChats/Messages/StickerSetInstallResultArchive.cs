using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class StickerSetInstallResultArchive : CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetInstallResultBase
	{


        public static int StaticConstructorId { get => 904138920; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("sets")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase> Sets { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Sets);

		}

		public override void Deserialize(Reader reader)
		{
			Sets = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase>();

		}
				
		public override string ToString()
		{
		    return "messages.stickerSetInstallResultArchive";
		}
	}
}