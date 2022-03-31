using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputMessagesFilterUrl : CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 2129714567; }
        

        
        public InputMessagesFilterUrl() 
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
		    return "inputMessagesFilterUrl";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}