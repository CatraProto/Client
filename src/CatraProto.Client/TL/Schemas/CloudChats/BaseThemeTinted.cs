using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class BaseThemeTinted : CatraProto.Client.TL.Schemas.CloudChats.BaseThemeBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1834973166; }
        

        
        public BaseThemeTinted() 
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
		    return "baseThemeTinted";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}