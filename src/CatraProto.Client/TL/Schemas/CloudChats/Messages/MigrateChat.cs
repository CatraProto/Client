using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class MigrateChat : IMethod
    {
        public static int ConstructorId { get; } = 363051235;
        public int ChatId { get; set; }

        public Type Type { get; init; } = typeof(UpdatesBase);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(ChatId);
        }

        public void Deserialize(Reader reader)
        {
            ChatId = reader.Read<int>();
        }
    }
}