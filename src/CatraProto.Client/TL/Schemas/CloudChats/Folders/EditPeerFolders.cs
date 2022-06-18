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

namespace CatraProto.Client.TL.Schemas.CloudChats.Folders
{
    public partial class EditPeerFolders : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1749536939; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("folder_peers")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.InputFolderPeerBase> FolderPeers { get; set; }


#nullable enable
        public EditPeerFolders(List<CatraProto.Client.TL.Schemas.CloudChats.InputFolderPeerBase> folderPeers)
        {
            FolderPeers = folderPeers;

        }
#nullable disable

        internal EditPeerFolders()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkfolderPeers = writer.WriteVector(FolderPeers, false);
            if (checkfolderPeers.IsError)
            {
                return checkfolderPeers;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryfolderPeers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputFolderPeerBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryfolderPeers.IsError)
            {
                return ReadResult<IObject>.Move(tryfolderPeers);
            }
            FolderPeers = tryfolderPeers.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "folders.editPeerFolders";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new EditPeerFolders
            {
                FolderPeers = new List<CatraProto.Client.TL.Schemas.CloudChats.InputFolderPeerBase>()
            };
            foreach (var folderPeers in FolderPeers)
            {
                var clonefolderPeers = (CatraProto.Client.TL.Schemas.CloudChats.InputFolderPeerBase?)folderPeers.Clone();
                if (clonefolderPeers is null)
                {
                    return null;
                }
                newClonedObject.FolderPeers.Add(clonefolderPeers);
            }
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not EditPeerFolders castedOther)
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
            return false;

        }
#nullable disable
    }
}