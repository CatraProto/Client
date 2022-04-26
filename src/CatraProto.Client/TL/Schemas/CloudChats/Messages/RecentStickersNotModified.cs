using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class RecentStickersNotModified : CatraProto.Client.TL.Schemas.CloudChats.Messages.RecentStickersBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 186120336; }



        public RecentStickersNotModified()
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
            return "messages.recentStickersNotModified";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new RecentStickersNotModified();
            return newClonedObject;

        }
#nullable disable
    }
}