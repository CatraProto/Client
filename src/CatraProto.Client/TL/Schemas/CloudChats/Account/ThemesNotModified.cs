using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class ThemesNotModified : CatraProto.Client.TL.Schemas.CloudChats.Account.ThemesBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -199313886; }



        public ThemesNotModified()
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
            return "account.themesNotModified";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ThemesNotModified();
            return newClonedObject;

        }
#nullable disable
    }
}