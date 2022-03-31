using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class BaseThemeDay : CatraProto.Client.TL.Schemas.CloudChats.BaseThemeBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -69724536; }
        

        
        public BaseThemeDay() 
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
		    return "baseThemeDay";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}