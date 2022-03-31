using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UserStatusRecently : CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -496024847; }
        

        
        public UserStatusRecently() 
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
		    return "userStatusRecently";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}