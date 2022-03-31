using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.TL;

namespace CatraProto.Client.Updates.CustomTypes
{
    class UpdateRedirect : UpdatesBase
    {
        public UpdateBase Update { get; }

        public UpdateRedirect(UpdateBase update)
        {
            Update = update;
        }

        public override void Serialize(Writer writer)
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateFlags()
        {
            throw new System.NotImplementedException();
        }

        public override void Deserialize(Reader reader)
        {
            throw new System.NotImplementedException();
        }

        public override int GetConstructorId()
        {
            throw new System.NotImplementedException();
        }
    }
}