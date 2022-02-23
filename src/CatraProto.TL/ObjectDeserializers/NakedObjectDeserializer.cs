using CatraProto.TL.Interfaces;
using CatraProto.TL.Interfaces.Deserializers;

namespace CatraProto.TL.ObjectDeserializers
{
    public class NakedObjectVectorDeserializer<T> : ICustomVectorDeserializer<T> where T : IObject
    {
        private readonly ObjectProvider _objectProvider;

        public NakedObjectVectorDeserializer(ObjectProvider objectProvider)
        {
            _objectProvider = objectProvider;
        }

        public T GetValue(Reader reader)
        {
            var instance = (T)_objectProvider.GetNakedFromType(typeof(T))!;
            instance.Deserialize(reader);
            return instance;
        }
    }
}