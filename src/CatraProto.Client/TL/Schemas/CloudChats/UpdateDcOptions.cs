using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateDcOptions : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => -1906403213; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("dc_options")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.DcOptionBase> DcOptions { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(DcOptions);

		}

		public override void Deserialize(Reader reader)
		{
			DcOptions = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DcOptionBase>();

		}
				
		public override string ToString()
		{
		    return "updateDcOptions";
		}
	}
}