namespace CatraProto.TL.Interfaces
{
    public interface IObject
    {
        public void Deserialize(Reader reader);
        public void Serialize(Writer writer);
        public void UpdateFlags();
    }
}