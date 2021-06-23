using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public class UserInfo : UserInfoBase
    {
        public static int ConstructorId { get; } = 32192344;
        public string Message { get; set; }
        public IList<MessageEntityBase> Entities { get; set; }
        public string Author { get; set; }
        public int Date { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Message);
            writer.Write(Entities);
            writer.Write(Author);
            writer.Write(Date);
        }

        public override void Deserialize(Reader reader)
        {
            Message = reader.Read<string>();
            Entities = reader.ReadVector<MessageEntityBase>();
            Author = reader.Read<string>();
            Date = reader.Read<int>();
        }
    }
}