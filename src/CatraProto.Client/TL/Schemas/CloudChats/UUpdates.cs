using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UUpdates : UpdatesBase
    {
        public static int ConstructorId { get; } = 1957577280;
        public IList<UpdateBase> Updates { get; set; }
        public IList<UserBase> Users { get; set; }
        public IList<ChatBase> Chats { get; set; }
        public int Date { get; set; }
        public int Seq { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Updates);
            writer.Write(Users);
            writer.Write(Chats);
            writer.Write(Date);
            writer.Write(Seq);
        }

        public override void Deserialize(Reader reader)
        {
            Updates = reader.ReadVector<UpdateBase>();
            Users = reader.ReadVector<UserBase>();
            Chats = reader.ReadVector<ChatBase>();
            Date = reader.Read<int>();
            Seq = reader.Read<int>();
        }
    }
}