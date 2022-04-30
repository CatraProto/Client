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

using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class TermsOfService : CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Popup = 1 << 0,
            MinAgeConfirm = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 2013922064; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("popup")]
        public sealed override bool Popup { get; set; }

        [Newtonsoft.Json.JsonProperty("id")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Id { get; set; }

        [Newtonsoft.Json.JsonProperty("text")]
        public sealed override string Text { get; set; }

        [Newtonsoft.Json.JsonProperty("entities")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

        [Newtonsoft.Json.JsonProperty("min_age_confirm")]
        public sealed override int? MinAgeConfirm { get; set; }


#nullable enable
        public TermsOfService(CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase id, string text, List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> entities)
        {
            Id = id;
            Text = text;
            Entities = entities;

        }
#nullable disable
        internal TermsOfService()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Popup ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = MinAgeConfirm == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkid = writer.WriteObject(Id);
            if (checkid.IsError)
            {
                return checkid;
            }

            writer.WriteString(Text);
            var checkentities = writer.WriteVector(Entities, false);
            if (checkentities.IsError)
            {
                return checkentities;
            }
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt32(MinAgeConfirm.Value);
            }


            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            Popup = FlagsHelper.IsFlagSet(Flags, 0);
            var tryid = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            var trytext = reader.ReadString();
            if (trytext.IsError)
            {
                return ReadResult<IObject>.Move(trytext);
            }
            Text = trytext.Value;
            var tryentities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryentities.IsError)
            {
                return ReadResult<IObject>.Move(tryentities);
            }
            Entities = tryentities.Value;
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryminAgeConfirm = reader.ReadInt32();
                if (tryminAgeConfirm.IsError)
                {
                    return ReadResult<IObject>.Move(tryminAgeConfirm);
                }
                MinAgeConfirm = tryminAgeConfirm.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "help.termsOfService";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new TermsOfService
            {
                Flags = Flags,
                Popup = Popup
            };
            var cloneId = (CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase?)Id.Clone();
            if (cloneId is null)
            {
                return null;
            }
            newClonedObject.Id = cloneId;
            newClonedObject.Text = Text;
            foreach (var entities in Entities)
            {
                var cloneentities = (CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase?)entities.Clone();
                if (cloneentities is null)
                {
                    return null;
                }
                newClonedObject.Entities.Add(cloneentities);
            }
            newClonedObject.MinAgeConfirm = MinAgeConfirm;
            return newClonedObject;

        }
#nullable disable
    }
}