namespace CatraProto.TL.Interfaces.Deserializers
{
    public interface ICustomVectorDeserializer<out T>
    {
        public T GetValue(Reader reader);
    }
}