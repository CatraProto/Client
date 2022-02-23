using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class DialogPeerFolder : CatraProto.Client.TL.Schemas.CloudChats.DialogPeerBase
    {
        public static int StaticConstructorId
        {
            get => 1363483106;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("folder_id")]
        public int FolderId { get; set; }


    #nullable enable
        public DialogPeerFolder(int folderId)
        {
            FolderId = folderId;
        }
    #nullable disable
        internal DialogPeerFolder()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(FolderId);
        }

        public override void Deserialize(Reader reader)
        {
            FolderId = reader.Read<int>();
        }

        public override string ToString()
        {
            return "dialogPeerFolder";
        }
    }
}