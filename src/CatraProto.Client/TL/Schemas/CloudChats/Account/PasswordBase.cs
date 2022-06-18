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

using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class PasswordBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("has_recovery")]
        public abstract bool HasRecovery { get; set; }

        [Newtonsoft.Json.JsonProperty("has_secure_values")]
        public abstract bool HasSecureValues { get; set; }

        [Newtonsoft.Json.JsonProperty("has_password")]
        public abstract bool HasPassword { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("current_algo")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase CurrentAlgo { get; set; }

        [Newtonsoft.Json.JsonProperty("srp_B")]
        public abstract byte[] SrpB { get; set; }

        [Newtonsoft.Json.JsonProperty("srp_id")]
        public abstract long? SrpId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("hint")]
        public abstract string Hint { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("email_unconfirmed_pattern")]
        public abstract string EmailUnconfirmedPattern { get; set; }

        [Newtonsoft.Json.JsonProperty("new_algo")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase NewAlgo { get; set; }

        [Newtonsoft.Json.JsonProperty("new_secure_algo")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase NewSecureAlgo { get; set; }

        [Newtonsoft.Json.JsonProperty("secure_random")]
        public abstract byte[] SecureRandom { get; set; }

        [Newtonsoft.Json.JsonProperty("pending_reset_date")]
        public abstract int? PendingResetDate { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
        public abstract bool Compare(IObject other);
#nullable disable
    }
}
