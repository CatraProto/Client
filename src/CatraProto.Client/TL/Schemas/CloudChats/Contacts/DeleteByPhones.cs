using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class DeleteByPhones : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 269745566;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("phones")] public IList<string> Phones { get; set; }

        public override string ToString()
        {
            return "contacts.deleteByPhones";
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

            writer.Write(Phones);
        }

        public void Deserialize(Reader reader)
        {
            Phones = reader.ReadVector<string>();
        }
    }
}