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

using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class WebAuthorization : CatraProto.Client.TL.Schemas.CloudChats.WebAuthorizationBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1493633966; }

        [Newtonsoft.Json.JsonProperty("hash")]
        public sealed override long Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("bot_id")]
        public sealed override long BotId { get; set; }

        [Newtonsoft.Json.JsonProperty("domain")]
        public sealed override string Domain { get; set; }

        [Newtonsoft.Json.JsonProperty("browser")]
        public sealed override string Browser { get; set; }

        [Newtonsoft.Json.JsonProperty("platform")]
        public sealed override string Platform { get; set; }

        [Newtonsoft.Json.JsonProperty("date_created")]
        public sealed override int DateCreated { get; set; }

        [Newtonsoft.Json.JsonProperty("date_active")]
        public sealed override int DateActive { get; set; }

        [Newtonsoft.Json.JsonProperty("ip")]
        public sealed override string Ip { get; set; }

        [Newtonsoft.Json.JsonProperty("region")]
        public sealed override string Region { get; set; }


#nullable enable
        public WebAuthorization(long hash, long botId, string domain, string browser, string platform, int dateCreated, int dateActive, string ip, string region)
        {
            Hash = hash;
            BotId = botId;
            Domain = domain;
            Browser = browser;
            Platform = platform;
            DateCreated = dateCreated;
            DateActive = dateActive;
            Ip = ip;
            Region = region;

        }
#nullable disable
        internal WebAuthorization()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Hash);
            writer.WriteInt64(BotId);

            writer.WriteString(Domain);

            writer.WriteString(Browser);

            writer.WriteString(Platform);
            writer.WriteInt32(DateCreated);
            writer.WriteInt32(DateActive);

            writer.WriteString(Ip);

            writer.WriteString(Region);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryhash = reader.ReadInt64();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }
            Hash = tryhash.Value;
            var trybotId = reader.ReadInt64();
            if (trybotId.IsError)
            {
                return ReadResult<IObject>.Move(trybotId);
            }
            BotId = trybotId.Value;
            var trydomain = reader.ReadString();
            if (trydomain.IsError)
            {
                return ReadResult<IObject>.Move(trydomain);
            }
            Domain = trydomain.Value;
            var trybrowser = reader.ReadString();
            if (trybrowser.IsError)
            {
                return ReadResult<IObject>.Move(trybrowser);
            }
            Browser = trybrowser.Value;
            var tryplatform = reader.ReadString();
            if (tryplatform.IsError)
            {
                return ReadResult<IObject>.Move(tryplatform);
            }
            Platform = tryplatform.Value;
            var trydateCreated = reader.ReadInt32();
            if (trydateCreated.IsError)
            {
                return ReadResult<IObject>.Move(trydateCreated);
            }
            DateCreated = trydateCreated.Value;
            var trydateActive = reader.ReadInt32();
            if (trydateActive.IsError)
            {
                return ReadResult<IObject>.Move(trydateActive);
            }
            DateActive = trydateActive.Value;
            var tryip = reader.ReadString();
            if (tryip.IsError)
            {
                return ReadResult<IObject>.Move(tryip);
            }
            Ip = tryip.Value;
            var tryregion = reader.ReadString();
            if (tryregion.IsError)
            {
                return ReadResult<IObject>.Move(tryregion);
            }
            Region = tryregion.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "webAuthorization";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new WebAuthorization
            {
                Hash = Hash,
                BotId = BotId,
                Domain = Domain,
                Browser = Browser,
                Platform = Platform,
                DateCreated = DateCreated,
                DateActive = DateActive,
                Ip = Ip,
                Region = Region
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not WebAuthorization castedOther)
            {
                return true;
            }
            if (Hash != castedOther.Hash)
            {
                return true;
            }
            if (BotId != castedOther.BotId)
            {
                return true;
            }
            if (Domain != castedOther.Domain)
            {
                return true;
            }
            if (Browser != castedOther.Browser)
            {
                return true;
            }
            if (Platform != castedOther.Platform)
            {
                return true;
            }
            if (DateCreated != castedOther.DateCreated)
            {
                return true;
            }
            if (DateActive != castedOther.DateActive)
            {
                return true;
            }
            if (Ip != castedOther.Ip)
            {
                return true;
            }
            if (Region != castedOther.Region)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}