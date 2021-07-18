using System;
using CatraProto.TL.Interfaces;

namespace CatraProto.TL.ObjectDeserializers
{
    public class NakedObjectDeserializer<T> : ICustomDeserializer<T> where T : IObject
    {
        public T GetValue(Reader reader)
        {
            var instance = Activator.CreateInstance<T>();
            instance.Deserialize(reader);
            return instance;
        }
    }
}