using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputPeerEmpty : CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 2134579434; }



        public InputPeerEmpty()
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
            return "inputPeerEmpty";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputPeerEmpty();
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not InputPeerEmpty castedOther)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}