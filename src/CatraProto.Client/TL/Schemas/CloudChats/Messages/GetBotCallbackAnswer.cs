using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

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

        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1824339449;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(BotCallbackAnswerBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonIgnore] public int Flags { get; set; }

        [JsonProperty("game")] public bool Game { get; set; }

        [JsonProperty("peer")] public InputPeerBase Peer { get; set; }

        [JsonProperty("msg_id")] public int MsgId { get; set; }

        [JsonProperty("data")] public byte[] Data { get; set; }

        [JsonProperty("password")] public InputCheckPasswordSRPBase Password { get; set; }

        public override string ToString()
        {
            return "messages.getBotCallbackAnswer";
        }


        public void UpdateFlags()
        {
            Flags = Game ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Data == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Password == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
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