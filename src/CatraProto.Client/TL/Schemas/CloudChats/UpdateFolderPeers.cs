/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateFolderPeers : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 422972864; }

        [Newtonsoft.Json.JsonProperty("folder_peers")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.FolderPeerBase> FolderPeers { get; set; }

        [Newtonsoft.Json.JsonProperty("pts")]
        public int Pts { get; set; }

        [Newtonsoft.Json.JsonProperty("pts_count")]
        public int PtsCount { get; set; }


#nullable enable
        public UpdateFolderPeers(List<CatraProto.Client.TL.Schemas.CloudChats.FolderPeerBase> folderPeers, int pts, int ptsCount)
        {
            FolderPeers = folderPeers;
            Pts = pts;
            PtsCount = ptsCount;

        }
#nullable disable
        internal UpdateFolderPeers()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkfolderPeers = writer.WriteVector(FolderPeers, false);
            if (checkfolderPeers.IsError)
            {
                return checkfolderPeers;
            }
            writer.WriteInt32(Pts);
            writer.WriteInt32(PtsCount);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryfolderPeers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.FolderPeerBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryfolderPeers.IsError)
            {
                return ReadResult<IObject>.Move(tryfolderPeers);
            }
            FolderPeers = tryfolderPeers.Value;
            var trypts = reader.ReadInt32();
            if (trypts.IsError)
            {
                return ReadResult<IObject>.Move(trypts);
            }
            Pts = trypts.Value;
            var tryptsCount = reader.ReadInt32();
            if (tryptsCount.IsError)
            {
                return ReadResult<IObject>.Move(tryptsCount);
            }
            PtsCount = tryptsCount.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updateFolderPeers";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateFolderPeers
            {
                FolderPeers = new List<CatraProto.Client.TL.Schemas.CloudChats.FolderPeerBase>()
            };
            foreach (var folderPeers in FolderPeers)
            {
                var clonefolderPeers = (CatraProto.Client.TL.Schemas.CloudChats.FolderPeerBase?)folderPeers.Clone();
                if (clonefolderPeers is null)
                {
                    return null;
                }
                newClonedObject.FolderPeers.Add(clonefolderPeers);
            }
            newClonedObject.Pts = Pts;
            newClonedObject.PtsCount = PtsCount;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateFolderPeers castedOther)
            {
                return true;
            }
            var folderPeerssize = castedOther.FolderPeers.Count;
            if (folderPeerssize != FolderPeers.Count)
            {
                return true;
            }
            for (var i = 0; i < folderPeerssize; i++)
            {
                if (castedOther.FolderPeers[i].Compare(FolderPeers[i]))
                {
                    return true;
                }
            }
            if (Pts != castedOther.Pts)
            {
                return true;
            }
            if (PtsCount != castedOther.PtsCount)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}