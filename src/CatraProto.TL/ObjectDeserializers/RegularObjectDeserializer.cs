using System;
using CatraProto.TL.Interfaces;

namespace CatraProto.TL.ObjectDeserializers
{
    public class RegularObjectDeserializer<T> : ICustomDeserializer<T>
    {
        private Type _type;
        public RegularObjectDeserializer(Type type)
        {
            _type = type;
        }
        
        public T GetValue(Reader reader)
        {
            return (T)reader.Read(_type);
        }
    }
}