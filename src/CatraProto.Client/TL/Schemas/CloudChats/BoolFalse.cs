using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class BoolFalse : IObject
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1132882121; }



        public BoolFalse()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "boolFalse";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new BoolFalse();
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not BoolFalse castedOther)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}