using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UserProfilePhotoEmpty : CatraProto.Client.TL.Schemas.CloudChats.UserProfilePhotoBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1326562017; }
        

        
        public UserProfilePhotoEmpty() 
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
		    return "userProfilePhotoEmpty";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}