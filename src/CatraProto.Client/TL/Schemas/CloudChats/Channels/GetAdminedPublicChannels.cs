using System;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class GetAdminedPublicChannels : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            ByLocation = 1 << 0,
            CheckLimit = 1 << 1
        }

        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -122669393;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(ChatsBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonIgnore] public int Flags { get; set; }

        [JsonProperty("by_location")] public bool ByLocation { get; set; }

        [JsonProperty("check_limit")] public bool CheckLimit { get; set; }

        public override string ToString()
        {
            return "channels.getAdminedPublicChannels";
        }


        public void UpdateFlags()
        {
            Flags = ByLocation ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = CheckLimit ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            ByLocation = FlagsHelper.IsFlagSet(Flags, 0);
            CheckLimit = FlagsHelper.IsFlagSet(Flags, 1);
        }
    }
}