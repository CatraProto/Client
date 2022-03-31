using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class PassportConfigNotModified : CatraProto.Client.TL.Schemas.CloudChats.Help.PassportConfigBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1078332329; }
        

        
        public PassportConfigNotModified() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);

		}

		public override void Deserialize(Reader reader)
		{

		}
		
		public override string ToString()
		{
		    return "help.passportConfigNotModified";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}