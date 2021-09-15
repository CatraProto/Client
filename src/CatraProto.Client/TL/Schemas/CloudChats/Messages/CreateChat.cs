using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class CreateChat : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 164303470;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(UpdatesBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("users")] public IList<InputUserBase> Users { get; set; }

        [JsonProperty("title")] public string Title { get; set; }

        public override string ToString()
        {
            return "messages.createChat";
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

            writer.Write(Users);
            writer.Write(Title);
        }

        public void Deserialize(Reader reader)
        {
            Users = reader.ReadVector<InputUserBase>();
            Title = reader.Read<string>();
        }
    }
}