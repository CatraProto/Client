#nullable disable
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

namespace CatraProto.Client.TL.Schemas.FileContexts
{
    public partial class ContextUnrecoverable : CatraProto.Client.TL.Schemas.FileContexts.ContextBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 588158055; }

        [Newtonsoft.Json.JsonProperty("contextType")]
        public int ContextType { get; set; }


#nullable enable
        public ContextUnrecoverable(int contextType)
        {
            ContextType = contextType;
        }
#nullable disable
        internal ContextUnrecoverable()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(ContextType);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycontextType = reader.ReadInt32();
            if (trycontextType.IsError)
            {
                return ReadResult<IObject>.Move(trycontextType);
            }

            ContextType = trycontextType.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "contextUnrecoverable";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ContextUnrecoverable();
            newClonedObject.ContextType = ContextType;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ContextUnrecoverable castedOther)
            {
                return true;
            }

            if (ContextType != castedOther.ContextType)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}