using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetBotCallbackAnswer : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Game = 1 << 1,
            Data = 1 << 0,
            Password = 1 << 2
        }

        public static int ConstructorId { get; } = -1824339449;
        public int Flags { get; set; }
        public bool Game { get; set; }
        public InputPeerBase Peer { get; set; }
        public int MsgId { get; set; }
        public byte[] Data { get; set; }
        public InputCheckPasswordSRPBase Password { get; set; }

        public Type Type { get; init; } = typeof(BotCallbackAnswerBase);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
            Flags = Game ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Data == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Password == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Peer);
            writer.Write(MsgId);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(Data);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.Write(Password);
            }
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Game = FlagsHelper.IsFlagSet(Flags, 1);
            Peer = reader.Read<InputPeerBase>();
            MsgId = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                Data = reader.Read<byte[]>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                Password = reader.Read<InputCheckPasswordSRPBase>();
            }
        }
    }
}