using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InlineQueryPeerTypeSameBotPM : CatraProto.Client.TL.Schemas.CloudChats.InlineQueryPeerTypeBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 813821341; }



        public InlineQueryPeerTypeSameBotPM()
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
            return "inlineQueryPeerTypeSameBotPM";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InlineQueryPeerTypeSameBotPM();
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not InlineQueryPeerTypeSameBotPM castedOther)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}