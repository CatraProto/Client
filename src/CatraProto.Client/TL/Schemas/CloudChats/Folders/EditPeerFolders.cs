using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Folders
{
    public partial class EditPeerFolders : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1749536939;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(UpdatesBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("folder_peers")] public IList<InputFolderPeerBase> FolderPeers { get; set; }

        public override string ToString()
        {
            return "folders.editPeerFolders";
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

            writer.Write(FolderPeers);
        }

        public void Deserialize(Reader reader)
        {
            FolderPeers = reader.ReadVector<InputFolderPeerBase>();
        }
    }
}