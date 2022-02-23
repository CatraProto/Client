using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class FaveSticker : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1174420133;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(bool);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("id")] public CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Id { get; set; }

        [Newtonsoft.Json.JsonProperty("unfave")]
        public bool Unfave { get; set; }


    #nullable enable
        public FaveSticker(CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase id, bool unfave)
        {
            Id = id;
            Unfave = unfave;
        }
    #nullable disable

        internal FaveSticker()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Id);
            writer.Write(Unfave);
        }

        public void Deserialize(Reader reader)
        {
            Id = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();
            Unfave = reader.Read<bool>();
        }

        public override string ToString()
        {
            return "messages.faveSticker";
        }
    }
}