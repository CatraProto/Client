using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class DialogFilterSuggested : DialogFilterSuggestedBase
	{


        public static int ConstructorId { get; } = 2004110666;
		public override CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase Filter { get; set; }
		public override string Description { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Filter);
			writer.Write(Description);

		}

		public override void Deserialize(Reader reader)
		{
			Filter = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase>();
			Description = reader.Read<string>();

		}
	}
}