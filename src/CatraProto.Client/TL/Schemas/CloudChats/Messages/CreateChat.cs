using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class CreateChat : IMethod
    {
        public static int ConstructorId { get; } = 164303470;

        public System.Type Type { get; init; } = typeof(UpdatesBase);
        public bool IsVector { get; init; } = false;
        public IList<InputUserBase> Users { get; set; }
        public string Title { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Users);
            writer.Write(Title);
        }

        public void Deserialize(Reader reader)
        {
            Users = reader.ReadVector<InputUserBase>();
            Title = reader.Read<string>();
        }
    }
}