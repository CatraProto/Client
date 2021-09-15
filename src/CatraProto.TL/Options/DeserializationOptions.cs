using CatraProto.TL.Interfaces;

namespace CatraProto.TL.Options
{
    public readonly struct DeserializationOptions
    {
        public IObject? ToInstance { get; }

        public DeserializationOptions(IObject toInstance)
        {
            ToInstance = toInstance;
        }
    }
}