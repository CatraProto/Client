using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class BoolTrue : IObject
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1720552011; }



        public BoolTrue()
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
            return "boolTrue";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new BoolTrue();
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not BoolTrue castedOther)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}