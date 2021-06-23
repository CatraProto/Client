using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
    public class GetChannelDifference : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Force = 1 << 0
        }

        public static int ConstructorId { get; } = 51854712;

        public System.Type Type { get; init; } = typeof(ChannelDifferenceBase);
        public bool IsVector { get; init; } = false;
        public int Flags { get; set; }
        public bool Force { get; set; }
        public InputChannelBase Channel { get; set; }
        public ChannelMessagesFilterBase Filter { get; set; }
        public int Pts { get; set; }
        public int Limit { get; set; }

        public void UpdateFlags()
        {
            Flags = Force ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Channel);
            writer.Write(Filter);
            writer.Write(Pts);
            writer.Write(Limit);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Force = FlagsHelper.IsFlagSet(Flags, 0);
            Channel = reader.Read<InputChannelBase>();
            Filter = reader.Read<ChannelMessagesFilterBase>();
            Pts = reader.Read<int>();
            Limit = reader.Read<int>();
        }
    }
}