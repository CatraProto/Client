using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class ImportAuthorization : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -1518699091; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("id")]
		public long Id { get; set; }

[Newtonsoft.Json.JsonProperty("bytes")]
		public byte[] Bytes { get; set; }

        
        #nullable enable
 public ImportAuthorization (long id,byte[] bytes)
{
 Id = id;
Bytes = bytes;
 
}
#nullable disable
                
        internal ImportAuthorization() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Bytes);

		}

		public void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			Bytes = reader.Read<byte[]>();

		}
		
		public override string ToString()
		{
		    return "auth.importAuthorization";
		}
	}
}