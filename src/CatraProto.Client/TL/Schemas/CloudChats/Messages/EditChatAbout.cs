using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class EditChatAbout : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -554301545; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("about")]
        public string About { get; set; }


#nullable enable
        public EditChatAbout(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string about)
        {
            Peer = peer;
            About = about;
        }
#nullable disable

        internal EditChatAbout()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            writer.WriteString(About);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var tryabout = reader.ReadString();
            if (tryabout.IsError)
            {
                return ReadResult<IObject>.Move(tryabout);
            }

            About = tryabout.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.editChatAbout";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new EditChatAbout();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.About = About;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not EditChatAbout castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (About != castedOther.About)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}