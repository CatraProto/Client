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
    public partial class SecureValueErrorTranslationFiles : CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 878931416; }

        [Newtonsoft.Json.JsonProperty("type")] public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase Type { get; set; }

        [Newtonsoft.Json.JsonProperty("file_hash")]
        public List<byte[]> FileHash { get; set; }

        [Newtonsoft.Json.JsonProperty("text")] public sealed override string Text { get; set; }


#nullable enable
        public SecureValueErrorTranslationFiles(CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase type, List<byte[]> fileHash, string text)
        {
            Type = type;
            FileHash = fileHash;
            Text = text;
        }
#nullable disable
        internal SecureValueErrorTranslationFiles()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checktype = writer.WriteObject(Type);
            if (checktype.IsError)
            {
                return checktype;
            }

            writer.WriteVector(FileHash, false);

            writer.WriteString(Text);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytype = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase>();
            if (trytype.IsError)
            {
                return ReadResult<IObject>.Move(trytype);
            }

            Type = trytype.Value;
            var tryfileHash = reader.ReadVector<byte[]>(ParserTypes.Bytes, nakedVector: false, nakedObjects: false);
            if (tryfileHash.IsError)
            {
                return ReadResult<IObject>.Move(tryfileHash);
            }

            FileHash = tryfileHash.Value;
            var trytext = reader.ReadString();
            if (trytext.IsError)
            {
                return ReadResult<IObject>.Move(trytext);
            }

            Text = trytext.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "secureValueErrorTranslationFiles";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SecureValueErrorTranslationFiles();
            var cloneType = (CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase?)Type.Clone();
            if (cloneType is null)
            {
                return null;
            }

            newClonedObject.Type = cloneType;
            newClonedObject.FileHash = new List<byte[]>();
            foreach (var fileHash in FileHash)
            {
                newClonedObject.FileHash.Add(fileHash);
            }

            newClonedObject.Text = Text;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not SecureValueErrorTranslationFiles castedOther)
            {
                return true;
            }

            if (Type.Compare(castedOther.Type))
            {
                return true;
            }

            var fileHashsize = castedOther.FileHash.Count;
            if (fileHashsize != FileHash.Count)
            {
                return true;
            }

            for (var i = 0; i < fileHashsize; i++)
            {
                if (castedOther.FileHash[i] != FileHash[i])
                {
                    return true;
                }
            }

            if (Text != castedOther.Text)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}