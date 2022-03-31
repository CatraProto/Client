using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UserStatusEmpty : CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 164646985; }
        

        
        public UserStatusEmpty() 
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
		    return "userStatusEmpty";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}