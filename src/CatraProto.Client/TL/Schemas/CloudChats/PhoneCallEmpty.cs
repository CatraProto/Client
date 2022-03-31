using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhoneCallEmpty : CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1399245077; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public sealed override long Id { get; set; }


        #nullable enable
 public PhoneCallEmpty (long id)
{
 Id = id;
 
}
#nullable disable
        internal PhoneCallEmpty() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Id);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();

		}
		
		public override string ToString()
		{
		    return "phoneCallEmpty";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}