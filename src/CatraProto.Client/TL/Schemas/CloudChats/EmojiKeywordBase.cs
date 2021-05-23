using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class EmojiKeywordBase : IObject
    {
		public abstract string Keyword { get; set; }
		public abstract IList<string> Emoticons { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
