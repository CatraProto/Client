using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelParticipantsAdmins : CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantsFilterBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1268741783; }



        public ChannelParticipantsAdmins()
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
            return "channelParticipantsAdmins";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelParticipantsAdmins();
            return newClonedObject;

        }
#nullable disable
    }
}