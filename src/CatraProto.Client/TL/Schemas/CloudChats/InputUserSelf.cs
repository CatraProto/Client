using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputUserSelf : CatraProto.Client.TL.Schemas.CloudChats.InputUserBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -138301121; }
        

        
        public InputUserSelf() 
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
		    return "inputUserSelf";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}