using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class WebDocumentNoProxy : WebDocumentBase
    {
        public static int ConstructorId { get; } = -104284986;
        public override string Url { get; set; }
        public override int Size { get; set; }
        public override string MimeType { get; set; }
        public override IList<DocumentAttributeBase> Attributes { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Url);
            writer.Write(Size);
            writer.Write(MimeType);
            writer.Write(Attributes);
        }

        public override void Deserialize(Reader reader)
        {
            Url = reader.Read<string>();
            Size = reader.Read<int>();
            MimeType = reader.Read<string>();
            Attributes = reader.ReadVector<DocumentAttributeBase>();
        }
    }
}