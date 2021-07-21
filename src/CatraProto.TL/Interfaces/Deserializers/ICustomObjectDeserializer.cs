namespace CatraProto.TL.Interfaces.Deserializers
{
    public interface ICustomObjectDeserializer
    {
        public bool DeserializeObject(IObject obj, Reader reader);
    }
}