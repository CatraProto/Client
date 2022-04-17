using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

namespace CatraProto.Client.Updates.CustomTypes
{
    internal class UpdateRedirect : UpdatesBase
    {
        public UpdateBase Update { get; }

        public UpdateRedirect(UpdateBase update)
        {
            Update = update;
        }

        public override WriteResult Serialize(Writer writer)
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateFlags()
        {
            throw new System.NotImplementedException();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            throw new System.NotImplementedException();
        }

        public override int GetConstructorId()
        {
            throw new System.NotImplementedException();
        }
    }
}