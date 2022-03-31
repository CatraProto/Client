using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputNotifyUsers : CatraProto.Client.TL.Schemas.CloudChats.InputNotifyPeerBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 423314455; }
        

        
        public InputNotifyUsers() 
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
		    return "inputNotifyUsers";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}