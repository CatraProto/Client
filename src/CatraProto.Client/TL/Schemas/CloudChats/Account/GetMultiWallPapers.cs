using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetMultiWallPapers : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1705865692; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = true;

[Newtonsoft.Json.JsonProperty("wallpapers")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase> Wallpapers { get; set; }

        
        #nullable enable
 public GetMultiWallPapers (IList<CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase> wallpapers)
{
 Wallpapers = wallpapers;
 
}
#nullable disable
                
        internal GetMultiWallPapers() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Wallpapers);

		}

		public void Deserialize(Reader reader)
		{
			Wallpapers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase>();

		}
		
		public override string ToString()
		{
		    return "account.getMultiWallPapers";
		}
	}
}