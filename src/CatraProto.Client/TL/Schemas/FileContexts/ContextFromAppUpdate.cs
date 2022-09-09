#nullable disable
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

namespace CatraProto.Client.TL.Schemas.FileContexts
{
    public partial class ContextFromAppUpdate : CatraProto.Client.TL.Schemas.FileContexts.ContextBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -2056114134; }

        [Newtonsoft.Json.JsonProperty("source")]
        public string Source { get; set; }


#nullable enable
        public ContextFromAppUpdate(string source)
        {
            Source = source;
        }
#nullable disable
        internal ContextFromAppUpdate()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Source);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trysource = reader.ReadString();
            if (trysource.IsError)
            {
                return ReadResult<IObject>.Move(trysource);
            }

            Source = trysource.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "contextFromAppUpdate";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ContextFromAppUpdate();
            newClonedObject.Source = Source;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ContextFromAppUpdate castedOther)
            {
                return true;
            }

            if (Source != castedOther.Source)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}