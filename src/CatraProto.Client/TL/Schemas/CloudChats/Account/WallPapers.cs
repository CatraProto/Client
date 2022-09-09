using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class WallPapers : CatraProto.Client.TL.Schemas.CloudChats.Account.WallPapersBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -842824308; }

        [Newtonsoft.Json.JsonProperty("hash")] public long Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("wallpapers")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase> Wallpapers { get; set; }


#nullable enable
        public WallPapers(long hash, List<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase> wallpapers)
        {
            Hash = hash;
            Wallpapers = wallpapers;
        }
#nullable disable
        internal WallPapers()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Hash);
            var checkwallpapers = writer.WriteVector(Wallpapers, false);
            if (checkwallpapers.IsError)
            {
                return checkwallpapers;
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
            var trywallpapers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trywallpapers.IsError)
            {
                return ReadResult<IObject>.Move(trywallpapers);
            }

            Wallpapers = trywallpapers.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.wallPapers";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new WallPapers();
            newClonedObject.Hash = Hash;
            newClonedObject.Wallpapers = new List<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase>();
            foreach (var wallpapers in Wallpapers)
            {
                var clonewallpapers = (CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase?)wallpapers.Clone();
                if (clonewallpapers is null)
                {
                    return null;
                }

                newClonedObject.Wallpapers.Add(clonewallpapers);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not WallPapers castedOther)
            {
                return true;
            }

            if (Hash != castedOther.Hash)
            {
                return true;
            }

            var wallpaperssize = castedOther.Wallpapers.Count;
            if (wallpaperssize != Wallpapers.Count)
            {
                return true;
            }

            for (var i = 0; i < wallpaperssize; i++)
            {
                if (castedOther.Wallpapers[i].Compare(Wallpapers[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}