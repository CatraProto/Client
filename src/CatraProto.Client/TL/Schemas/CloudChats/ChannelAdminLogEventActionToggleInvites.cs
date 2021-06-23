using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class ChannelAdminLogEventActionToggleInvites : ChannelAdminLogEventActionBase
    {
        public static int ConstructorId { get; } = 460916654;
        public bool NewValue { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(NewValue);
        }

        public override void Deserialize(Reader reader)
        {
            NewValue = reader.Read<bool>();
        }
    }
}