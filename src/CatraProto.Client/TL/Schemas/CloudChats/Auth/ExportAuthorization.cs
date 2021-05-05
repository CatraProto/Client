using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class ExportAuthorization : IMethod<ExportedAuthorizationBase>
    {
        public static int ConstructorId { get; } = -440401971;
        public int DcId { get; set; }

        public Type Type { get; init; } = typeof(ExportAuthorization);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(DcId);
        }

        public void Deserialize(Reader reader)
        {
            DcId = reader.Read<int>();
        }
    }
}