using CatraProto.TL;

namespace CatraProto.Client.MTProto.Session.Interfaces
{
    interface ISessionSerializer
    {
        public void Read(Reader reader);
        public void Save(Writer writer);
    }
}