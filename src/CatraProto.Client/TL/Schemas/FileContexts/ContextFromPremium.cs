#nullable disable
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

namespace CatraProto.Client.TL.Schemas.FileContexts
{
    public partial class ContextFromPremium : CatraProto.Client.TL.Schemas.FileContexts.ContextBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -879560365; }


        public ContextFromPremium()
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
            return "contextFromPremium";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ContextFromPremium();
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ContextFromPremium castedOther)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}