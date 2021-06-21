using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class LangPackDifferenceBase : IObject
    {
        public abstract string LangCode { get; set; }
        public abstract int FromVersion { get; set; }
        public abstract int Version { get; set; }
        public abstract IList<LangPackStringBase> Strings { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}