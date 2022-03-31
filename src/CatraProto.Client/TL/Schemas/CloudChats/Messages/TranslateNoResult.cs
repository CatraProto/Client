using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class TranslateNoResult : CatraProto.Client.TL.Schemas.CloudChats.Messages.TranslatedTextBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1741309751; }
        

        
        public TranslateNoResult() 
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
		    return "messages.translateNoResult";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}