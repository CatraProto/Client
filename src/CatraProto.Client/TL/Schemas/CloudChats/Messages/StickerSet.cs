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
    public partial class StickerSet : CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1240849242; }

        [Newtonsoft.Json.JsonProperty("set")] public CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase Set { get; set; }

        [Newtonsoft.Json.JsonProperty("packs")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase> Packs { get; set; }

        [Newtonsoft.Json.JsonProperty("documents")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Documents { get; set; }


#nullable enable
        public StickerSet(CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase set, List<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase> packs, List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> documents)
        {
            Set = set;
            Packs = packs;
            Documents = documents;
        }
#nullable disable
        internal StickerSet()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkset = writer.WriteObject(Set);
            if (checkset.IsError)
            {
                return checkset;
            }

            var checkpacks = writer.WriteVector(Packs, false);
            if (checkpacks.IsError)
            {
                return checkpacks;
            }

            var checkdocuments = writer.WriteVector(Documents, false);
            if (checkdocuments.IsError)
            {
                return checkdocuments;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryset = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase>();
            if (tryset.IsError)
            {
                return ReadResult<IObject>.Move(tryset);
            }

            Set = tryset.Value;
            var trypacks = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trypacks.IsError)
            {
                return ReadResult<IObject>.Move(trypacks);
            }

            Packs = trypacks.Value;
            var trydocuments = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trydocuments.IsError)
            {
                return ReadResult<IObject>.Move(trydocuments);
            }

            Documents = trydocuments.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.stickerSet";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new StickerSet();
            var cloneSet = (CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase?)Set.Clone();
            if (cloneSet is null)
            {
                return null;
            }

            newClonedObject.Set = cloneSet;
            newClonedObject.Packs = new List<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase>();
            foreach (var packs in Packs)
            {
                var clonepacks = (CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase?)packs.Clone();
                if (clonepacks is null)
                {
                    return null;
                }

                newClonedObject.Packs.Add(clonepacks);
            }

            newClonedObject.Documents = new List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
            foreach (var documents in Documents)
            {
                var clonedocuments = (CatraProto.Client.TL.Schemas.CloudChats.DocumentBase?)documents.Clone();
                if (clonedocuments is null)
                {
                    return null;
                }

                newClonedObject.Documents.Add(clonedocuments);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not StickerSet castedOther)
            {
                return true;
            }

            if (Set.Compare(castedOther.Set))
            {
                return true;
            }

            var packssize = castedOther.Packs.Count;
            if (packssize != Packs.Count)
            {
                return true;
            }

            for (var i = 0; i < packssize; i++)
            {
                if (castedOther.Packs[i].Compare(Packs[i]))
                {
                    return true;
                }
            }

            var documentssize = castedOther.Documents.Count;
            if (documentssize != Documents.Count)
            {
                return true;
            }

            for (var i = 0; i < documentssize; i++)
            {
                if (castedOther.Documents[i].Compare(Documents[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}