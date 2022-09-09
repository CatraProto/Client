using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public abstract class SupportBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("phone_number")]
        public abstract string PhoneNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("user")] public abstract CatraProto.Client.TL.Schemas.CloudChats.UserBase User { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
        public abstract bool Compare(IObject other);
#nullable disable
    }
}