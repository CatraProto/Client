using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public class Themes : ThemesBase
    {
        public static int ConstructorId { get; } = 2137482273;
        public int Hash { get; set; }
        public IList<ThemeBase> Themes_ { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Hash);
            writer.Write(Themes_);
        }

        public override void Deserialize(Reader reader)
        {
            Hash = reader.Read<int>();
            Themes_ = reader.ReadVector<ThemeBase>();
        }
    }
}