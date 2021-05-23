using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class SupportName : SupportNameBase
	{


        public static int ConstructorId { get; } = -1945767479;
		public override string Name { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Name);

		}

		public override void Deserialize(Reader reader)
		{
			Name = reader.Read<string>();

		}
	}
}