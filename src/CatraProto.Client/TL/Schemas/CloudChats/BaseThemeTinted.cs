using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class BaseThemeTinted : CatraProto.Client.TL.Schemas.CloudChats.BaseThemeBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1834973166; }



        public BaseThemeTinted()
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
            return "baseThemeTinted";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new BaseThemeTinted();
            return newClonedObject;

        }
#nullable disable
    }
}