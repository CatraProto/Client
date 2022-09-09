using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageMediaWebPage : CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1557277184; }

        [Newtonsoft.Json.JsonProperty("webpage")]
        public CatraProto.Client.TL.Schemas.CloudChats.WebPageBase Webpage { get; set; }


#nullable enable
        public MessageMediaWebPage(CatraProto.Client.TL.Schemas.CloudChats.WebPageBase webpage)
        {
            Webpage = webpage;
        }
#nullable disable
        internal MessageMediaWebPage()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkwebpage = writer.WriteObject(Webpage);
            if (checkwebpage.IsError)
            {
                return checkwebpage;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trywebpage = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.WebPageBase>();
            if (trywebpage.IsError)
            {
                return ReadResult<IObject>.Move(trywebpage);
            }

            Webpage = trywebpage.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messageMediaWebPage";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageMediaWebPage();
            var cloneWebpage = (CatraProto.Client.TL.Schemas.CloudChats.WebPageBase?)Webpage.Clone();
            if (cloneWebpage is null)
            {
                return null;
            }

            newClonedObject.Webpage = cloneWebpage;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageMediaWebPage castedOther)
            {
                return true;
            }

            if (Webpage.Compare(castedOther.Webpage))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}