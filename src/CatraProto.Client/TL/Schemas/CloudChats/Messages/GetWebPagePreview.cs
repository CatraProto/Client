using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetWebPagePreview : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Entities = 1 << 3
        }

        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1956073268;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(MessageMediaBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonIgnore] public int Flags { get; set; }

        [JsonProperty("message")] public string Message { get; set; }

        [JsonProperty("entities")] public IList<MessageEntityBase> Entities { get; set; }

        public override string ToString()
        {
            return "messages.getWebPagePreview";
        }


        public void UpdateFlags()
        {
            Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Message);
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.Write(Entities);
            }
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Message = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                Entities = reader.ReadVector<MessageEntityBase>();
            }
        }
    }
}