using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Folders
{
    public partial class EditPeerFolders : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1749536939; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

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
            var newClonedObject = new EditPeerFolders();
            newClonedObject.FolderPeers = new List<CatraProto.Client.TL.Schemas.CloudChats.InputFolderPeerBase>();
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