using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public class DiscardCall : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Video = 1 << 0
        }

        public static int ConstructorId { get; } = -1295269440;

        public System.Type Type { get; init; } = typeof(UpdatesBase);
        public bool IsVector { get; init; } = false;
        public int Flags { get; set; }
        public bool Video { get; set; }
        public InputPhoneCallBase Peer { get; set; }
        public int Duration { get; set; }
        public PhoneCallDiscardReasonBase Reason { get; set; }
        public long ConnectionId { get; set; }

        public void UpdateFlags()
        {
            Flags = Video ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Peer);
            writer.Write(Duration);
            writer.Write(Reason);
            writer.Write(ConnectionId);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Video = FlagsHelper.IsFlagSet(Flags, 0);
            Peer = reader.Read<InputPhoneCallBase>();
            Duration = reader.Read<int>();
            Reason = reader.Read<PhoneCallDiscardReasonBase>();
            ConnectionId = reader.Read<long>();
        }
    }
}