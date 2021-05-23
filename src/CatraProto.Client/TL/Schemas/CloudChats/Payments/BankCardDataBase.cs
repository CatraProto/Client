using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public abstract class BankCardDataBase : IObject
    {
		public abstract string Title { get; set; }
		public abstract IList<BankCardOpenUrlBase> OpenUrls { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
