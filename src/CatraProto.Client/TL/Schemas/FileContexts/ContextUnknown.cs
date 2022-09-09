#nullable disable
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

namespace CatraProto.Client.TL.Schemas.FileContexts
{
    public partial class ContextUnknown : CatraProto.Client.TL.Schemas.FileContexts.ContextBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -2007996210; }


        public ContextUnknown()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "contextUnknown";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ContextUnknown();
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ContextUnknown castedOther)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}