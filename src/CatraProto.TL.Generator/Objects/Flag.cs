namespace CatraProto.TL.Generator.Objects
{
	public class Flag
	{
		public Flag(string name, int bit)
		{
			Name = name;
			Bit = bit;
		}

		public string Name { get; set; }
		public int Bit { get; set; }
	}
}