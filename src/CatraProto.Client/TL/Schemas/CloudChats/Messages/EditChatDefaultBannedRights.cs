using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class EditChatDefaultBannedRights : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1517917375;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(UpdatesBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("peer")] public InputPeerBase Peer { get; set; }

        [JsonProperty("banned_rights")] public ChatBannedRightsBase BannedRights { get; set; }

        public override string ToString()
        {
            return "messages.editChatDefaultBannedRights";
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

            writer.Write(Peer);
            writer.Write(BannedRights);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputPeerBase>();
            BannedRights = reader.Read<ChatBannedRightsBase>();
        }
    }
}