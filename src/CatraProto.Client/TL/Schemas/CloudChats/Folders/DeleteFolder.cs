using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Folders
{
    public partial class DeleteFolder : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 472471681;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(UpdatesBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("folder_id")] public int FolderId { get; set; }

        public override string ToString()
        {
            return "folders.deleteFolder";
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

            writer.Write(FolderId);
        }

        public void Deserialize(Reader reader)
        {
            FolderId = reader.Read<int>();
        }
    }
}