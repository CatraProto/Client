using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionChangeLocation : ChannelAdminLogEventActionBase
	{


        public static int ConstructorId { get; } = 241923758;
		public CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase PrevValue { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase NewValue { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PrevValue);
			writer.Write(NewValue);

		}

		public override void Deserialize(Reader reader)
		{
			PrevValue = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase>();
			NewValue = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase>();

		}
	}
}