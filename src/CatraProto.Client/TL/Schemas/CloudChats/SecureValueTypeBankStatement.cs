using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureValueTypeBankStatement : CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1995211763; }
        

        
        public SecureValueTypeBankStatement() 
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
		    return "secureValueTypeBankStatement";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}