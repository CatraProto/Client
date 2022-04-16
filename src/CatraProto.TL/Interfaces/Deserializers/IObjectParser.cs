using CatraProto.TL.Results;

namespace CatraProto.TL.Interfaces.Deserializers
{
    public interface IObjectParser
    {
        public bool CanReadObject(IObject obj);
        public ReadResult<IObject> ReadObject(IObject obj, Reader reader);
    }
}