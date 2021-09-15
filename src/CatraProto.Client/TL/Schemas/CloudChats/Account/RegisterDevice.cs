using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class RegisterDevice : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            NoMuted = 1 << 0
        }

        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1754754159;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonIgnore] public int Flags { get; set; }

        [JsonProperty("no_muted")] public bool NoMuted { get; set; }

        [JsonProperty("token_type")] public int TokenType { get; set; }

        [JsonProperty("token")] public string Token { get; set; }

        [JsonProperty("app_sandbox")] public bool AppSandbox { get; set; }

        [JsonProperty("secret")] public byte[] Secret { get; set; }

        [JsonProperty("other_uids")] public IList<int> OtherUids { get; set; }

        public override string ToString()
        {
            return "account.registerDevice";
        }


        public void UpdateFlags()
        {
            Flags = NoMuted ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(TokenType);
            writer.Write(Token);
            writer.Write(AppSandbox);
            writer.Write(Secret);
            writer.Write(OtherUids);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            NoMuted = FlagsHelper.IsFlagSet(Flags, 0);
            TokenType = reader.Read<int>();
            Token = reader.Read<string>();
            AppSandbox = reader.Read<bool>();
            Secret = reader.Read<byte[]>();
            OtherUids = reader.ReadVector<int>();
        }
    }
}