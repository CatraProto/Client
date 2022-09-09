using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputDialogPeerFolder : CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1684014375; }

        [Newtonsoft.Json.JsonProperty("folder_id")]
        public int FolderId { get; set; }


#nullable enable
        public InputDialogPeerFolder(int folderId)
        {
            FolderId = folderId;
        }
#nullable disable
        internal InputDialogPeerFolder()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(FolderId);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
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
            return "inputDialogPeerFolder";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputDialogPeerFolder();
            newClonedObject.FolderId = FolderId;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputDialogPeerFolder castedOther)
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