using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class ThemesNotModified : CatraProto.Client.TL.Schemas.CloudChats.Account.ThemesBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -199313886; }
        

        
        public ThemesNotModified() 
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
		    return "account.themesNotModified";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}