#nullable disable
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

namespace CatraProto.Client.TL.Schemas.FileContexts
{
    public partial class ContextFromRecentMeUrl : CatraProto.Client.TL.Schemas.FileContexts.ContextBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -785757945; }

        [Newtonsoft.Json.JsonProperty("referer")]
        public string Referer { get; set; }


#nullable enable
        public ContextFromRecentMeUrl(string referer)
        {
            Referer = referer;
        }
#nullable disable
        internal ContextFromRecentMeUrl()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Referer);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryreferer = reader.ReadString();
            if (tryreferer.IsError)
            {
                return ReadResult<IObject>.Move(tryreferer);
            }

            Referer = tryreferer.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "contextFromRecentMeUrl";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ContextFromRecentMeUrl();
            newClonedObject.Referer = Referer;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ContextFromRecentMeUrl castedOther)
            {
                return true;
            }

            if (Referer != castedOther.Referer)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}