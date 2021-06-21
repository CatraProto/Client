using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UserStatusOffline : UserStatusBase
    {
        public static int ConstructorId { get; } = 9203775;
        public int WasOnline { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(WasOnline);
        }

        public override void Deserialize(Reader reader)
        {
            WasOnline = reader.Read<int>();
        }
    }
}