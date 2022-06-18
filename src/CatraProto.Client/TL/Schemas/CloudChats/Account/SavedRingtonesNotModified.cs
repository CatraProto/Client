using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class SavedRingtonesNotModified : CatraProto.Client.TL.Schemas.CloudChats.Account.SavedRingtonesBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -67704655; }



        public SavedRingtonesNotModified()
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
            return "account.savedRingtonesNotModified";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SavedRingtonesNotModified();
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not SavedRingtonesNotModified castedOther)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}