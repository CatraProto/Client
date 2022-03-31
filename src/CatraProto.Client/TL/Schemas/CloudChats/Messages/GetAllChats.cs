using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetAllChats : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2023787330; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("except_ids")]
		public IList<long> ExceptIds { get; set; }

        
        #nullable enable
 public GetAllChats (IList<long> exceptIds)
{
 ExceptIds = exceptIds;
 
}
#nullable disable
                
        internal GetAllChats() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(ExceptIds);

		}

		public void Deserialize(Reader reader)
		{
			ExceptIds = reader.ReadVector<long>();

		}

		public override string ToString()
		{
		    return "messages.getAllChats";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}