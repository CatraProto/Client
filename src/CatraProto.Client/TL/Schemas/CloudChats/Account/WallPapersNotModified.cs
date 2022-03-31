using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class WallPapersNotModified : CatraProto.Client.TL.Schemas.CloudChats.Account.WallPapersBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 471437699; }
        

        
        public WallPapersNotModified() 
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
		    return "account.wallPapersNotModified";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}