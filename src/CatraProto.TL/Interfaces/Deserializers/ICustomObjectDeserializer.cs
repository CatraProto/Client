namespace CatraProto.TL.Interfaces.Deserializers
{
    public interface ICustomObjectDeserializer
    {
        public void DeserializeObject(IObject obj, Reader reader);
    }
}