using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class AcceptUrlAuth : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            WriteAllowed = 1 << 0
        }

        public static int ConstructorId { get; } = -148247912;

        public System.Type Type { get; init; } = typeof(UrlAuthResultBase);
        public bool IsVector { get; init; } = false;
        public int Flags { get; set; }
        public bool WriteAllowed { get; set; }
        public InputPeerBase Peer { get; set; }
        public int MsgId { get; set; }
        public int ButtonId { get; set; }

        public void UpdateFlags()
        {
            Flags = WriteAllowed ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
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
            writer.Write(MsgId);
            writer.Write(ButtonId);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            WriteAllowed = FlagsHelper.IsFlagSet(Flags, 0);
            Peer = reader.Read<InputPeerBase>();
            MsgId = reader.Read<int>();
            ButtonId = reader.Read<int>();
        }
    }
}