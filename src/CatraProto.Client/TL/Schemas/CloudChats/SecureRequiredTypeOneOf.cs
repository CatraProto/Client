using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SecureRequiredTypeOneOf : SecureRequiredTypeBase
    {
        public static int ConstructorId { get; } = 41187252;
        public IList<SecureRequiredTypeBase> Types { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Types);
        }

        public override void Deserialize(Reader reader)
        {
            Types = reader.ReadVector<SecureRequiredTypeBase>();
        }
    }
}