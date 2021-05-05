using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChatForbidden : ChatBase
    {
        public static int ConstructorId { get; } = 120753115;
        public override int Id { get; set; }
        public string Title { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Id);
            writer.Write(Title);
        }

        public override void Deserialize(Reader reader)
        {
            Id = reader.Read<int>();
            Title = reader.Read<string>();
        }
    }
}