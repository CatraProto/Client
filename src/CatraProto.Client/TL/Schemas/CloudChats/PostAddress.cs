using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PostAddress : PostAddressBase
	{
		public static int ConstructorId { get; } = 512535275;
		public override string StreetLine1 { get; set; }
		public override string StreetLine2 { get; set; }
		public override string City { get; set; }
		public override string State { get; set; }
		public override string CountryIso2 { get; set; }
		public override string PostCode { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(StreetLine1);
			writer.Write(StreetLine2);
			writer.Write(City);
			writer.Write(State);
			writer.Write(CountryIso2);
			writer.Write(PostCode);
		}

		public override void Deserialize(Reader reader)
		{
			StreetLine1 = reader.Read<string>();
			StreetLine2 = reader.Read<string>();
			City = reader.Read<string>();
			State = reader.Read<string>();
			CountryIso2 = reader.Read<string>();
			PostCode = reader.Read<string>();
		}
	}
}