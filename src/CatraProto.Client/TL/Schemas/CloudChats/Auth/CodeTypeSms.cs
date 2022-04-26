using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class CodeTypeSms : CatraProto.Client.TL.Schemas.CloudChats.Auth.CodeTypeBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1923290508; }



        public CodeTypeSms()
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
            return "auth.codeTypeSms";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new CodeTypeSms();
            return newClonedObject;

        }
#nullable disable
    }
}