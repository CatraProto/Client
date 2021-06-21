namespace CatraProto.TL.Interfaces
{
    public interface IObject
    {
        public static int ConstructorId { get; protected set; }

        public void Deserialize(Reader reader);
        public void Serialize(Writer writer);
        public void UpdateFlags();
    }
}