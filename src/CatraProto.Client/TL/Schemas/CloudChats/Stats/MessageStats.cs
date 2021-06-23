using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
    public class MessageStats : MessageStatsBase
    {
        public static int ConstructorId { get; } = -1986399595;
        public override StatsGraphBase ViewsGraph { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(ViewsGraph);
        }

        public override void Deserialize(Reader reader)
        {
            ViewsGraph = reader.Read<StatsGraphBase>();
        }
    }
}