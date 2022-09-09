using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class ExportedGroupCallInvite : CatraProto.Client.TL.Schemas.CloudChats.Phone.ExportedGroupCallInviteBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 541839704; }

        [Newtonsoft.Json.JsonProperty("link")] public sealed override string Link { get; set; }


#nullable enable
        public ExportedGroupCallInvite(string link)
        {
            Link = link;
        }
#nullable disable
        internal ExportedGroupCallInvite()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Link);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trylink = reader.ReadString();
            if (trylink.IsError)
            {
                return ReadResult<IObject>.Move(trylink);
            }

            Link = trylink.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "phone.exportedGroupCallInvite";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ExportedGroupCallInvite();
            newClonedObject.Link = Link;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ExportedGroupCallInvite castedOther)
            {
                return true;
            }

            if (Link != castedOther.Link)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}