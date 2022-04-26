using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class TopPeersDisabled : CatraProto.Client.TL.Schemas.CloudChats.Contacts.TopPeersBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1255369827; }



        public TopPeersDisabled()
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
            return "contacts.topPeersDisabled";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new TopPeersDisabled();
            return newClonedObject;

        }
#nullable disable
    }
}