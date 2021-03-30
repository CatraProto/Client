using CatraProto.TL.Interfaces;

namespace CatraProto.TL.UnitTests
{
    public class DummyObject : IObject
    {
        public string AString { get; set; }
        public int AnInt { get; set; }
        public double ADouble { get; set; }
        public byte AByte { get; set; }
        public byte[] AByteArray { get; set; }
        public bool ABool { get; set; }
        public IObject AnObject { get; set; }
        public void Deserialize(Reader reader)
        {
            throw new System.NotImplementedException();
        }

        public void Serialize(Writer writer)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateFlags()
        {
            throw new System.NotImplementedException();
        }
    }
}