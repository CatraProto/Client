using System;
using System.Collections.Generic;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class TermsOfService : TermsOfServiceBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Popup = 1 << 0,
            MinAgeConfirm = 1 << 1
        }

        public static int StaticConstructorId
        {
            get => 2013922064;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] public int Flags { get; set; }

        [JsonProperty("popup")] public override bool Popup { get; set; }

        [JsonProperty("id")] public override DataJSONBase Id { get; set; }

        [JsonProperty("text")] public override string Text { get; set; }

        [JsonProperty("entities")] public override IList<MessageEntityBase> Entities { get; set; }

        [JsonProperty("min_age_confirm")] public override int? MinAgeConfirm { get; set; }


        public override void UpdateFlags()
        {
            Flags = Popup ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = MinAgeConfirm == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Id);
            writer.Write(Text);
            writer.Write(Entities);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(MinAgeConfirm.Value);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Popup = FlagsHelper.IsFlagSet(Flags, 0);
            Id = reader.Read<DataJSONBase>();
            Text = reader.Read<string>();
            Entities = reader.ReadVector<MessageEntityBase>();
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                MinAgeConfirm = reader.Read<int>();
            }
        }

        public override string ToString()
        {
            return "help.termsOfService";
        }
    }
}