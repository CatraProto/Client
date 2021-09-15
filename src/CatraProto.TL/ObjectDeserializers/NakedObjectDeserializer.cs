using System;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Interfaces.Deserializers;

namespace CatraProto.TL.ObjectDeserializers
{
    public class NakedObjectVectorDeserializer<T> : ICustomVectorDeserializer<T> where T : IObject
    {
        public T GetValue(Reader reader)
        {
            var instance = Activator.CreateInstance<T>();
            instance.Deserialize(reader);
            return instance;
        }
    }
}