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
    public partial class UpdateLangPack : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1442983757; }

        [Newtonsoft.Json.JsonProperty("difference")]
        public CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase Difference { get; set; }


#nullable enable
        public UpdateLangPack(CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase difference)
        {
            Difference = difference;

        }
#nullable disable
        internal UpdateLangPack()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkdifference = writer.WriteObject(Difference);
            if (checkdifference.IsError)
            {
                return checkdifference;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydifference = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase>();
            if (trydifference.IsError)
            {
                return ReadResult<IObject>.Move(trydifference);
            }
            Difference = trydifference.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updateLangPack";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateLangPack();
            var cloneDifference = (CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase?)Difference.Clone();
            if (cloneDifference is null)
            {
                return null;
            }
            newClonedObject.Difference = cloneDifference;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateLangPack castedOther)
            {
                return true;
            }
            if (Difference.Compare(castedOther.Difference))
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}