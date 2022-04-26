using CatraProto.TL.Results;

namespace CatraProto.TL.Interfaces
{
    public interface IObject
    {
        public ReadResult<IObject> Deserialize(Reader reader);
        public WriteResult Serialize(Writer writer);
        public void UpdateFlags();
        public int GetConstructorId();
        public IObject? Clone();
    }
}