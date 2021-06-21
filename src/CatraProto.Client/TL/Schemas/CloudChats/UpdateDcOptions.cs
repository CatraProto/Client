using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateDcOptions : UpdateBase
    {
        public static int ConstructorId { get; } = -1906403213;
        public IList<DcOptionBase> DcOptions { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(DcOptions);
        }

        public override void Deserialize(Reader reader)
        {
            DcOptions = reader.ReadVector<DcOptionBase>();
        }
    }
}