using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class Stickers : CatraProto.Client.TL.Schemas.CloudChats.Messages.StickersBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 816245886; }
        
[Newtonsoft.Json.JsonProperty("hash")]
		public long Hash { get; set; }

[Newtonsoft.Json.JsonProperty("stickers")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> StickersField { get; set; }


        #nullable enable
 public Stickers (long hash,IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> stickersField)
{
 Hash = hash;
StickersField = stickersField;
 
}
#nullable disable
        internal Stickers() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Hash);
			writer.Write(StickersField);

		}

		public override void Deserialize(Reader reader)
		{
			Hash = reader.Read<long>();
			StickersField = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();

		}
		
		public override string ToString()
		{
		    return "messages.stickers";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}