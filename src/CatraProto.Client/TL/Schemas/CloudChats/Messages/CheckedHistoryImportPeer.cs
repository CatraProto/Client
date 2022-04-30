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
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class CheckedHistoryImportPeer : CatraProto.Client.TL.Schemas.CloudChats.Messages.CheckedHistoryImportPeerBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1571952873; }

        [Newtonsoft.Json.JsonProperty("confirm_text")]
        public sealed override string ConfirmText { get; set; }


#nullable enable
        public CheckedHistoryImportPeer(string confirmText)
        {
            ConfirmText = confirmText;

        }
#nullable disable
        internal CheckedHistoryImportPeer()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(ConfirmText);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryconfirmText = reader.ReadString();
            if (tryconfirmText.IsError)
            {
                return ReadResult<IObject>.Move(tryconfirmText);
            }
            ConfirmText = tryconfirmText.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.checkedHistoryImportPeer";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new CheckedHistoryImportPeer
            {
                ConfirmText = ConfirmText
            };
            return newClonedObject;

        }
#nullable disable
    }
}