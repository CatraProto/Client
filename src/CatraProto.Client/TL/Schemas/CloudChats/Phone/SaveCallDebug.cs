using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class SaveCallDebug : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 662363518; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("debug")]
		public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Debug { get; set; }

        
        #nullable enable
 public SaveCallDebug (CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer,CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase debug)
{
 Peer = peer;
Debug = debug;
 
}
#nullable disable
                
        internal SaveCallDebug() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Debug);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase>();
			Debug = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();

		}

		public override string ToString()
		{
		    return "phone.saveCallDebug";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}