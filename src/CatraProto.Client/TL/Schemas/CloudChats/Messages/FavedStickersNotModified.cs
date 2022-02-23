using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class FavedStickersNotModified : CatraProto.Client.TL.Schemas.CloudChats.Messages.FavedStickersBase
    {
        public static int StaticConstructorId
        {
            get => -1634752813;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public FavedStickersNotModified()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
        }

        public override void Deserialize(Reader reader)
        {
        }

        public override string ToString()
        {
            return "messages.favedStickersNotModified";
        }
    }
}