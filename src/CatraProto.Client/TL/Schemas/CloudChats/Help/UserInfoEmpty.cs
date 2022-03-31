using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class UserInfoEmpty : CatraProto.Client.TL.Schemas.CloudChats.Help.UserInfoBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -206688531; }
        

        
        public UserInfoEmpty() 
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
		    return "help.userInfoEmpty";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}