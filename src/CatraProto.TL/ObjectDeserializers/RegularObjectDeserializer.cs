using System;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Interfaces.Deserializers;

namespace CatraProto.TL.ObjectDeserializers
{
    public class RegularObjectVectorDeserializer<T> : ICustomVectorDeserializer<T>
    {
        private Type _type;
        public RegularObjectVectorDeserializer(Type type)
        {
            _type = type;
        }
        
        public T GetValue(Reader reader)
        {
            return (T)reader.Read(_type);
        }
    }
}