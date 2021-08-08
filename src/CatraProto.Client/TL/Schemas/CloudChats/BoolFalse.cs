using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class BoolFalse : IObject
	{


        public static int StaticConstructorId { get => -1132882121; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);

		}

		public void Deserialize(Reader reader)
		{

		}
	}
}