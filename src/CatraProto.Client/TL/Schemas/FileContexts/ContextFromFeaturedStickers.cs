#nullable disable
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

namespace CatraProto.Client.TL.Schemas.FileContexts
{
    public partial class ContextFromFeaturedStickers : CatraProto.Client.TL.Schemas.FileContexts.ContextBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1407104707; }


        public ContextFromFeaturedStickers()
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
            return "contextFromFeaturedStickers";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ContextFromFeaturedStickers();
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ContextFromFeaturedStickers castedOther)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}