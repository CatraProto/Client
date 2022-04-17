using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class Themes : CatraProto.Client.TL.Schemas.CloudChats.Account.ThemesBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1707242387; }
        
[Newtonsoft.Json.JsonProperty("hash")]
		public long Hash { get; set; }

[Newtonsoft.Json.JsonProperty("themes")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase> ThemesField { get; set; }


        #nullable enable
 public Themes (long hash,List<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase> themesField)
{
 Hash = hash;
ThemesField = themesField;
 
}
#nullable disable
        internal Themes() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
writer.WriteInt64(Hash);
var checkthemesField = 			writer.WriteVector(ThemesField, false);
if(checkthemesField.IsError){
 return checkthemesField; 
}

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryhash = reader.ReadInt64();
if(tryhash.IsError){
return ReadResult<IObject>.Move(tryhash);
}
Hash = tryhash.Value;
			var trythemesField = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(trythemesField.IsError){
return ReadResult<IObject>.Move(trythemesField);
}
ThemesField = trythemesField.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "account.themes";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}