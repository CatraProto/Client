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
	public partial class MessageEntityCode : CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 681706865; }
        
[Newtonsoft.Json.JsonProperty("offset")]
		public sealed override int Offset { get; set; }

[Newtonsoft.Json.JsonProperty("length")]
		public sealed override int Length { get; set; }


        #nullable enable
 public MessageEntityCode (int offset,int length)
{
 Offset = offset;
Length = length;
 
}
#nullable disable
        internal MessageEntityCode() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
writer.WriteInt32(Offset);
writer.WriteInt32(Length);

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryoffset = reader.ReadInt32();
if(tryoffset.IsError){
return ReadResult<IObject>.Move(tryoffset);
}
Offset = tryoffset.Value;
			var trylength = reader.ReadInt32();
if(trylength.IsError){
return ReadResult<IObject>.Move(trylength);
}
Length = trylength.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "messageEntityCode";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}