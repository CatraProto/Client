namespace CatraProto.TL.Interfaces
{
    public interface ICustomDeserializer<out T>
    {
        public T GetValue(Reader reader);
    }
}