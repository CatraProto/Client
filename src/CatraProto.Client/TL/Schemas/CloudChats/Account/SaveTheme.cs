using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SaveTheme : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -229175188; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("theme")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase Theme { get; set; }

[Newtonsoft.Json.JsonProperty("unsave")]
		public bool Unsave { get; set; }

        
        #nullable enable
 public SaveTheme (CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase theme,bool unsave)
{
 Theme = theme;
Unsave = unsave;
 
}
#nullable disable
                
        internal SaveTheme() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Theme);
			writer.Write(Unsave);

		}

		public void Deserialize(Reader reader)
		{
			Theme = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase>();
			Unsave = reader.Read<bool>();

		}

		public override string ToString()
		{
		    return "account.saveTheme";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}