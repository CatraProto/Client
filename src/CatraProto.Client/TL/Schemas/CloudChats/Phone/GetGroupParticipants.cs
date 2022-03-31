using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class GetGroupParticipants : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -984033109; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupParticipantsBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("call")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

[Newtonsoft.Json.JsonProperty("ids")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> Ids { get; set; }

[Newtonsoft.Json.JsonProperty("sources")]
		public IList<int> Sources { get; set; }

[Newtonsoft.Json.JsonProperty("offset")]
		public string Offset { get; set; }

[Newtonsoft.Json.JsonProperty("limit")]
		public int Limit { get; set; }

        
        #nullable enable
 public GetGroupParticipants (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call,IList<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> ids,IList<int> sources,string offset,int limit)
{
 Call = call;
Ids = ids;
Sources = sources;
Offset = offset;
Limit = limit;
 
}
#nullable disable
                
        internal GetGroupParticipants() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Call);
			writer.Write(Ids);
			writer.Write(Sources);
			writer.Write(Offset);
			writer.Write(Limit);

		}

		public void Deserialize(Reader reader)
		{
			Call = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
			Ids = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			Sources = reader.ReadVector<int>();
			Offset = reader.Read<string>();
			Limit = reader.Read<int>();

		}

		public override string ToString()
		{
		    return "phone.getGroupParticipants";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}