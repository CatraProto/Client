using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class EditLocation : IMethod<bool>
	{


        public static int ConstructorId { get; } = 1491484525;

		public InputChannelBase Channel { get; set; }
		public InputGeoPointBase GeoPoint { get; set; }
		public string Address { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Channel);
			writer.Write(GeoPoint);
			writer.Write(Address);

		}

		public void Deserialize(Reader reader)
		{
			Channel = reader.Read<InputChannelBase>();
			GeoPoint = reader.Read<InputGeoPointBase>();
			Address = reader.Read<string>();

		}
	}
}