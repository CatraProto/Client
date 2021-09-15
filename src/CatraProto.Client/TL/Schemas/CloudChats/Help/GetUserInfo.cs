using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class GetUserInfo : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 59377875;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(UserInfoBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("user_id")] public InputUserBase UserId { get; set; }

        public override string ToString()
        {
            return "help.getUserInfo";
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
        }

        public void Deserialize(Reader reader)
        {
            UserId = reader.Read<InputUserBase>();
        }
    }
}