using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPhoneCall : CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 506920429; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public sealed override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public sealed override long AccessHash { get; set; }


        #nullable enable
 public InputPhoneCall (long id,long accessHash)
{
 Id = id;
AccessHash = accessHash;
 
}
#nullable disable
        internal InputPhoneCall() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
writer.WriteInt64(Id);
writer.WriteInt64(AccessHash);

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryid = reader.ReadInt64();
if(tryid.IsError){
return ReadResult<IObject>.Move(tryid);
}
Id = tryid.Value;
			var tryaccessHash = reader.ReadInt64();
if(tryaccessHash.IsError){
return ReadResult<IObject>.Move(tryaccessHash);
}
AccessHash = tryaccessHash.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "inputPhoneCall";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}