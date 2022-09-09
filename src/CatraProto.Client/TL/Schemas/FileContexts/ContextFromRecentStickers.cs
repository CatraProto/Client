#nullable disable
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

namespace CatraProto.Client.TL.Schemas.FileContexts
{
    public partial class ContextFromRecentStickers : CatraProto.Client.TL.Schemas.FileContexts.ContextBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 484237748; }

        [Newtonsoft.Json.JsonProperty("isAttached")]
        public bool IsAttached { get; set; }


#nullable enable
        public ContextFromRecentStickers(bool isAttached)
        {
            IsAttached = isAttached;
        }
#nullable disable
        internal ContextFromRecentStickers()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkisAttached = writer.WriteBool(IsAttached);
            if (checkisAttached.IsError)
            {
                return checkisAttached;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryisAttached = reader.ReadBool();
            if (tryisAttached.IsError)
            {
                return ReadResult<IObject>.Move(tryisAttached);
            }

            IsAttached = tryisAttached.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "contextFromRecentStickers";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ContextFromRecentStickers();
            newClonedObject.IsAttached = IsAttached;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ContextFromRecentStickers castedOther)
            {
                return true;
            }

            if (IsAttached != castedOther.IsAttached)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}