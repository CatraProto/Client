using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class SetInlineGameScore : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            EditMessage = 1 << 0,
            Force = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 363700068;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(bool);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("edit_message")]
        public bool EditMessage { get; set; }

        [Newtonsoft.Json.JsonProperty("force")]
        public bool Force { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase Id { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("score")]
        public int Score { get; set; }


    #nullable enable
        public SetInlineGameScore(CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase id, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, int score)
        {
            Id = id;
            UserId = userId;
            Score = score;
        }
    #nullable disable

        internal SetInlineGameScore()
        {
        }

        public void UpdateFlags()
        {
            Flags = EditMessage ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Force ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Id);
            writer.Write(UserId);
            writer.Write(Score);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            EditMessage = FlagsHelper.IsFlagSet(Flags, 0);
            Force = FlagsHelper.IsFlagSet(Flags, 1);
            Id = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase>();
            UserId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            Score = reader.Read<int>();
        }

        public override string ToString()
        {
            return "messages.setInlineGameScore";
        }
    }
}