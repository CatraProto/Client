using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UserStatusLastMonth : CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 2011940674; }
        

        
        public UserStatusLastMonth() 
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
		    return "userStatusLastMonth";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}