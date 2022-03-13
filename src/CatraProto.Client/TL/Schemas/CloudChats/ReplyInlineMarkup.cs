using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ReplyInlineMarkup : CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase
	{


        public static int StaticConstructorId { get => 1218642516; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("rows")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRowBase> Rows { get; set; }


        #nullable enable
 public ReplyInlineMarkup (IList<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRowBase> rows)
{
 Rows = rows;
 
}
#nullable disable
        internal ReplyInlineMarkup() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Rows);

		}

		public override void Deserialize(Reader reader)
		{
			Rows = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRowBase>();

		}
				
		public override string ToString()
		{
		    return "replyInlineMarkup";
		}
	}
}