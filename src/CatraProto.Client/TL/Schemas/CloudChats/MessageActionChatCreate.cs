using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class MessageActionChatCreate : MessageActionBase
    {
        public static int ConstructorId { get; } = -1503425638;
        public string Title { get; set; }
        public IList<int> Users { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Title);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Title = reader.Read<string>();
            Users = reader.ReadVector<int>();
        }
    }
}