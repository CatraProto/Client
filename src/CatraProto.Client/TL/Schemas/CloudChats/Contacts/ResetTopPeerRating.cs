using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class ResetTopPeerRating : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 451113900; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("category")]
        public CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase Category { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }


#nullable enable
        public ResetTopPeerRating(CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase category, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer)
        {
            Category = category;
            Peer = peer;
        }
#nullable disable

        internal ResetTopPeerRating()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkcategory = writer.WriteObject(Category);
            if (checkcategory.IsError)
            {
                return checkcategory;
            }

            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycategory = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase>();
            if (trycategory.IsError)
            {
                return ReadResult<IObject>.Move(trycategory);
            }

            Category = trycategory.Value;
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "contacts.resetTopPeerRating";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ResetTopPeerRating();
            var cloneCategory = (CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase?)Category.Clone();
            if (cloneCategory is null)
            {
                return null;
            }

            newClonedObject.Category = cloneCategory;
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ResetTopPeerRating castedOther)
            {
                return true;
            }

            if (Category.Compare(castedOther.Category))
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}