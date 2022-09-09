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
    public partial class DeleteFolder : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 472471681; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("folder_id")]
        public int FolderId { get; set; }


#nullable enable
        public DeleteFolder(int folderId)
        {
            FolderId = folderId;
        }
#nullable disable

        internal DeleteFolder()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(FolderId);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryfolderId = reader.ReadInt32();
            if (tryfolderId.IsError)
            {
                return ReadResult<IObject>.Move(tryfolderId);
            }

            FolderId = tryfolderId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "folders.deleteFolder";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new DeleteFolder();
            newClonedObject.FolderId = FolderId;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not DeleteFolder castedOther)
            {
                return true;
            }

            if (FolderId != castedOther.FolderId)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}