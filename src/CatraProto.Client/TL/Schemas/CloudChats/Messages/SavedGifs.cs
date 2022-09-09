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
    public partial class SavedGifs : CatraProto.Client.TL.Schemas.CloudChats.Messages.SavedGifsBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -2069878259; }

        [Newtonsoft.Json.JsonProperty("hash")] public long Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("gifs")] public List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Gifs { get; set; }


#nullable enable
        public SavedGifs(long hash, List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> gifs)
        {
            Hash = hash;
            Gifs = gifs;
        }
#nullable disable
        internal SavedGifs()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Hash);
            var checkgifs = writer.WriteVector(Gifs, false);
            if (checkgifs.IsError)
            {
                return checkgifs;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryhash = reader.ReadInt64();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }

            Hash = tryhash.Value;
            var trygifs = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trygifs.IsError)
            {
                return ReadResult<IObject>.Move(trygifs);
            }

            Gifs = trygifs.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.savedGifs";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SavedGifs();
            newClonedObject.Hash = Hash;
            newClonedObject.Gifs = new List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
            foreach (var gifs in Gifs)
            {
                var clonegifs = (CatraProto.Client.TL.Schemas.CloudChats.DocumentBase?)gifs.Clone();
                if (clonegifs is null)
                {
                    return null;
                }

                newClonedObject.Gifs.Add(clonegifs);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not SavedGifs castedOther)
            {
                return true;
            }

            if (Hash != castedOther.Hash)
            {
                return true;
            }

            var gifssize = castedOther.Gifs.Count;
            if (gifssize != Gifs.Count)
            {
                return true;
            }

            for (var i = 0; i < gifssize; i++)
            {
                if (castedOther.Gifs[i].Compare(Gifs[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}