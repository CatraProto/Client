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
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class TermsOfServiceUpdate : CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceUpdateBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 686618977; }

        [Newtonsoft.Json.JsonProperty("expires")]
        public sealed override int Expires { get; set; }

        [Newtonsoft.Json.JsonProperty("terms_of_service")]
        public CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceBase TermsOfService { get; set; }


#nullable enable
        public TermsOfServiceUpdate(int expires, CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceBase termsOfService)
        {
            Expires = expires;
            TermsOfService = termsOfService;

        }
#nullable disable
        internal TermsOfServiceUpdate()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Expires);
            var checktermsOfService = writer.WriteObject(TermsOfService);
            if (checktermsOfService.IsError)
            {
                return checktermsOfService;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryexpires = reader.ReadInt32();
            if (tryexpires.IsError)
            {
                return ReadResult<IObject>.Move(tryexpires);
            }
            Expires = tryexpires.Value;
            var trytermsOfService = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceBase>();
            if (trytermsOfService.IsError)
            {
                return ReadResult<IObject>.Move(trytermsOfService);
            }
            TermsOfService = trytermsOfService.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "help.termsOfServiceUpdate";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new TermsOfServiceUpdate
            {
                Expires = Expires
            };
            var cloneTermsOfService = (CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceBase?)TermsOfService.Clone();
            if (cloneTermsOfService is null)
            {
                return null;
            }
            newClonedObject.TermsOfService = cloneTermsOfService;
            return newClonedObject;

        }
#nullable disable
    }
}