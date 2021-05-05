using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class Themes : ThemesBase
    {
        public static int ConstructorId { get; } = 2137482273;
        public int Hash { get; set; }
        public IList<ThemeBase> PThemes { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Hash);
            writer.Write(PThemes);
        }

        public override void Deserialize(Reader reader)
        {
            Hash = reader.Read<int>();
            PThemes = reader.ReadVector<ThemeBase>();
        }
    }
}