using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageTableRow : CatraProto.Client.TL.Schemas.CloudChats.PageTableRowBase
	{


        public static int StaticConstructorId { get => -524237339; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("cells")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.PageTableCellBase> Cells { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Cells);

		}

		public override void Deserialize(Reader reader)
		{
			Cells = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageTableCellBase>();

		}
	}
}