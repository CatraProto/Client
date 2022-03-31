using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class Takeout : CatraProto.Client.TL.Schemas.CloudChats.Account.TakeoutBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1304052993; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public sealed override long Id { get; set; }


        #nullable enable
 public Takeout (long id)
{
 Id = id;
 
}
#nullable disable
        internal Takeout() 
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
		    return "account.takeout";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}