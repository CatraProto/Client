using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class AllStickersNotModified : CatraProto.Client.TL.Schemas.CloudChats.Messages.AllStickersBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -395967805; }



        public AllStickersNotModified()
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
            return "messages.allStickersNotModified";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new AllStickersNotModified();
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not AllStickersNotModified castedOther)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}