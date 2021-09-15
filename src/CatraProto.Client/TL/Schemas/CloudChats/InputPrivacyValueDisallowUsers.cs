using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPrivacyValueDisallowUsers : CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyRuleBase
	{


        public static int StaticConstructorId { get => -1877932953; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("users")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase> Users { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();

		}
				
		public override string ToString()
		{
		    return "inputPrivacyValueDisallowUsers";
		}
	}
}