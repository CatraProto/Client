using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class ReplyInlineMarkup : ReplyMarkupBase
    {
        public static int ConstructorId { get; } = 1218642516;
        public IList<KeyboardButtonRowBase> Rows { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Rows);
        }

        public override void Deserialize(Reader reader)
        {
            Rows = reader.ReadVector<KeyboardButtonRowBase>();
        }
    }
}