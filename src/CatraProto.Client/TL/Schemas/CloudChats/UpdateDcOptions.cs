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

using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateDcOptions : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1906403213; }

        [Newtonsoft.Json.JsonProperty("dc_options")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.DcOptionBase> DcOptions { get; set; }


#nullable enable
        public UpdateDcOptions(List<CatraProto.Client.TL.Schemas.CloudChats.DcOptionBase> dcOptions)
        {
            DcOptions = dcOptions;

        }
#nullable disable
        internal UpdateDcOptions()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkdcOptions = writer.WriteVector(DcOptions, false);
            if (checkdcOptions.IsError)
            {
                return checkdcOptions;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydcOptions = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DcOptionBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trydcOptions.IsError)
            {
                return ReadResult<IObject>.Move(trydcOptions);
            }
            DcOptions = trydcOptions.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updateDcOptions";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateDcOptions
            {
                DcOptions = new List<CatraProto.Client.TL.Schemas.CloudChats.DcOptionBase>()
            };
            foreach (var dcOptions in DcOptions)
            {
                var clonedcOptions = (CatraProto.Client.TL.Schemas.CloudChats.DcOptionBase?)dcOptions.Clone();
                if (clonedcOptions is null)
                {
                    return null;
                }
                newClonedObject.DcOptions.Add(clonedcOptions);
            }
            return newClonedObject;

        }
#nullable disable
    }
}