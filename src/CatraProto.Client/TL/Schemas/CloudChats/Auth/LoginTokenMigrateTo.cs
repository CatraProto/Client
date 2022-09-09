using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class LoginTokenMigrateTo : CatraProto.Client.TL.Schemas.CloudChats.Auth.LoginTokenBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 110008598; }

        [Newtonsoft.Json.JsonProperty("dc_id")]
        public int DcId { get; set; }

        [Newtonsoft.Json.JsonProperty("token")]
        public byte[] Token { get; set; }


#nullable enable
        public LoginTokenMigrateTo(int dcId, byte[] token)
        {
            DcId = dcId;
            Token = token;
        }
#nullable disable
        internal LoginTokenMigrateTo()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(DcId);

            writer.WriteBytes(Token);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydcId = reader.ReadInt32();
            if (trydcId.IsError)
            {
                return ReadResult<IObject>.Move(trydcId);
            }

            DcId = trydcId.Value;
            var trytoken = reader.ReadBytes();
            if (trytoken.IsError)
            {
                return ReadResult<IObject>.Move(trytoken);
            }

            Token = trytoken.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "auth.loginTokenMigrateTo";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new LoginTokenMigrateTo();
            newClonedObject.DcId = DcId;
            newClonedObject.Token = Token;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not LoginTokenMigrateTo castedOther)
            {
                return true;
            }

            if (DcId != castedOther.DcId)
            {
                return true;
            }

            if (Token != castedOther.Token)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}