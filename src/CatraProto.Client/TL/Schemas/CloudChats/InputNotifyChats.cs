using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputNotifyChats : CatraProto.Client.TL.Schemas.CloudChats.InputNotifyPeerBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1251338318; }
        

        
        public InputNotifyChats() 
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
		    return "inputNotifyChats";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}