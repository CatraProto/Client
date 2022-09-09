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
    public partial class StatsGraphAsync : CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1244130093; }

        [Newtonsoft.Json.JsonProperty("token")]
        public string Token { get; set; }


#nullable enable
        public StatsGraphAsync(string token)
        {
            Token = token;
        }
#nullable disable
        internal StatsGraphAsync()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Token);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytoken = reader.ReadString();
            if (trytoken.IsError)
            {
                return ReadResult<IObject>.Move(trytoken);
            }

            Token = trytoken.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "statsGraphAsync";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new StatsGraphAsync();
            newClonedObject.Token = Token;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not StatsGraphAsync castedOther)
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