namespace CatraProto.TL.Generator.Objects
{
    public class Flag
    {
        public string Name { get; set; }
        public int Bit { get; set; }

        public Flag(string name, int bit)
        {
            Name = name;
            Bit = bit;
        }
    }
}