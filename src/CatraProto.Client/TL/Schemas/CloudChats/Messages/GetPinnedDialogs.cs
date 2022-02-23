using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetPinnedDialogs : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -692498958;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerDialogsBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("folder_id")]
        public int FolderId { get; set; }


    #nullable enable
        public GetPinnedDialogs(int folderId)
        {
            FolderId = folderId;
        }
    #nullable disable

        internal GetPinnedDialogs()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(FolderId);
        }

        public void Deserialize(Reader reader)
        {
            FolderId = reader.Read<int>();
        }

        public override string ToString()
        {
            return "messages.getPinnedDialogs";
        }
    }
}