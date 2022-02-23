using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class DeleteByPhones : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 269745566;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(bool);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("phones")]
        public IList<string> Phones { get; set; }


    #nullable enable
        public DeleteByPhones(IList<string> phones)
        {
            Phones = phones;
        }
    #nullable disable

        internal DeleteByPhones()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Phones);
        }

        public void Deserialize(Reader reader)
        {
            Phones = reader.ReadVector<string>();
        }

        public override string ToString()
        {
            return "contacts.deleteByPhones";
        }
    }
}