using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class EditAdmin : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -751007486;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(UpdatesBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("channel")] public InputChannelBase Channel { get; set; }

        [JsonProperty("user_id")] public InputUserBase UserId { get; set; }

        [JsonProperty("admin_rights")] public ChatAdminRightsBase AdminRights { get; set; }

        [JsonProperty("rank")] public string Rank { get; set; }

        public override string ToString()
        {
            return "channels.editAdmin";
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

            writer.Write(Channel);
            writer.Write(UserId);
            writer.Write(AdminRights);
            writer.Write(Rank);
        }

        public void Deserialize(Reader reader)
        {
            Channel = reader.Read<InputChannelBase>();
            UserId = reader.Read<InputUserBase>();
            AdminRights = reader.Read<ChatAdminRightsBase>();
            Rank = reader.Read<string>();
        }
    }
}