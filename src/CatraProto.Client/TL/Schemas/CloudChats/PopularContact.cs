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
    public partial class PopularContact : CatraProto.Client.TL.Schemas.CloudChats.PopularContactBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1558266229; }

        [Newtonsoft.Json.JsonProperty("client_id")]
        public sealed override long ClientId { get; set; }

        [Newtonsoft.Json.JsonProperty("importers")]
        public sealed override int Importers { get; set; }


#nullable enable
        public PopularContact(long clientId, int importers)
        {
            ClientId = clientId;
            Importers = importers;
        }
#nullable disable
        internal PopularContact()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(ClientId);
            writer.WriteInt32(Importers);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryclientId = reader.ReadInt64();
            if (tryclientId.IsError)
            {
                return ReadResult<IObject>.Move(tryclientId);
            }

            ClientId = tryclientId.Value;
            var tryimporters = reader.ReadInt32();
            if (tryimporters.IsError)
            {
                return ReadResult<IObject>.Move(tryimporters);
            }

            Importers = tryimporters.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "popularContact";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PopularContact();
            newClonedObject.ClientId = ClientId;
            newClonedObject.Importers = Importers;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PopularContact castedOther)
            {
                return true;
            }

            if (ClientId != castedOther.ClientId)
            {
                return true;
            }

            if (Importers != castedOther.Importers)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}