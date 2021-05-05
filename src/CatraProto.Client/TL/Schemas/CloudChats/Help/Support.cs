using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class Support : SupportBase
    {
        public static int ConstructorId { get; } = 398898678;
        public override string PhoneNumber { get; set; }
        public override UserBase User { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(PhoneNumber);
            writer.Write(User);
        }

        public override void Deserialize(Reader reader)
        {
            PhoneNumber = reader.Read<string>();
            User = reader.Read<UserBase>();
        }
    }
}