using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public abstract class CountriesListBase : IObject
    {

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
