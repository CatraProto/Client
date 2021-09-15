using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class FaveSticker : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1174420133;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("id")] public InputDocumentBase Id { get; set; }

        [JsonProperty("unfave")] public bool Unfave { get; set; }

        public override string ToString()
        {
            return "messages.faveSticker";
        }


        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Id);
            writer.Write(Unfave);
        }

        public void Deserialize(Reader reader)
        {
            Id = reader.Read<InputDocumentBase>();
            Unfave = reader.Read<bool>();
        }
    }
}