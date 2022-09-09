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
    public partial class InputWebFileLocation : CatraProto.Client.TL.Schemas.CloudChats.InputWebFileLocationBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1036396922; }

        [Newtonsoft.Json.JsonProperty("url")] public string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public sealed override long AccessHash { get; set; }


#nullable enable
        public InputWebFileLocation(string url, long accessHash)
        {
            Url = url;
            AccessHash = accessHash;
        }
#nullable disable
        internal InputWebFileLocation()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Url);
            writer.WriteInt64(AccessHash);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryurl = reader.ReadString();
            if (tryurl.IsError)
            {
                return ReadResult<IObject>.Move(tryurl);
            }

            Url = tryurl.Value;
            var tryaccessHash = reader.ReadInt64();
            if (tryaccessHash.IsError)
            {
                return ReadResult<IObject>.Move(tryaccessHash);
            }

            AccessHash = tryaccessHash.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputWebFileLocation";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputWebFileLocation();
            newClonedObject.Url = Url;
            newClonedObject.AccessHash = AccessHash;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputWebFileLocation castedOther)
            {
                return true;
            }

            if (Url != castedOther.Url)
            {
                return true;
            }

            if (AccessHash != castedOther.AccessHash)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}