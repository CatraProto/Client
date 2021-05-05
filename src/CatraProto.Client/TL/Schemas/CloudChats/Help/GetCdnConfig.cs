using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class GetCdnConfig : IMethod<CdnConfigBase>
    {
        public static int ConstructorId { get; } = 1375900482;

        public Type Type { get; init; } = typeof(GetCdnConfig);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
        }

        public void Deserialize(Reader reader)
        {
        }
    }
}