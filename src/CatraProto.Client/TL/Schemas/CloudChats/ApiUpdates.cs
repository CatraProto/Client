using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ApiUpdates : CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase
    {
        public static int StaticConstructorId
        {
            get => 1957577280;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("updates")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase> Updates { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("seq")] public int Seq { get; set; }


    #nullable enable
        public ApiUpdates(IList<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase> updates, IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users, IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, int date, int seq)
        {
            Updates = updates;
            Users = users;
            Chats = chats;
            Date = date;
            Seq = seq;
        }
    #nullable disable
        internal ApiUpdates()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Updates);
            writer.Write(Users);
            writer.Write(Chats);
            writer.Write(Date);
            writer.Write(Seq);
        }

        public override void Deserialize(Reader reader)
        {
            Updates = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase>();
            Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
            Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
            Date = reader.Read<int>();
            Seq = reader.Read<int>();
        }

        public override string ToString()
        {
            return "updates";
        }
    }
}