using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class AcceptContact : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -130964977;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("id")] public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase Id { get; set; }


    #nullable enable
        public AcceptContact(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase id)
        {
            Id = id;
        }
    #nullable disable

        internal AcceptContact()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Id);
        }

        public void Deserialize(Reader reader)
        {
            Id = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
        }

        public override string ToString()
        {
            return "contacts.acceptContact";
        }
    }
}