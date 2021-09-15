using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class EditUserInfo : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1723407216;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(UserInfoBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("user_id")] public InputUserBase UserId { get; set; }

        [JsonProperty("message")] public string Message { get; set; }

        [JsonProperty("entities")] public IList<MessageEntityBase> Entities { get; set; }

        public override string ToString()
        {
            return "help.editUserInfo";
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

            writer.Write(UserId);
            writer.Write(Message);
            writer.Write(Entities);
        }

        public void Deserialize(Reader reader)
        {
            UserId = reader.Read<InputUserBase>();
            Message = reader.Read<string>();
            Entities = reader.ReadVector<MessageEntityBase>();
        }
    }
}