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
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SecureRequiredType : CatraProto.Client.TL.Schemas.CloudChats.SecureRequiredTypeBase
    {
        [Flags]
        public enum FlagsEnum
        {
            NativeNames = 1 << 0,
            SelfieRequired = 1 << 1,
            TranslationRequired = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2103600678; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("native_names")]
        public bool NativeNames { get; set; }

        [Newtonsoft.Json.JsonProperty("selfie_required")]
        public bool SelfieRequired { get; set; }

        [Newtonsoft.Json.JsonProperty("translation_required")]
        public bool TranslationRequired { get; set; }

        [Newtonsoft.Json.JsonProperty("type")]
        public CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase Type { get; set; }


#nullable enable
        public SecureRequiredType(CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase type)
        {
            Type = type;

        }
#nullable disable
        internal SecureRequiredType()
        {
        }

        public override void UpdateFlags()
        {
            Flags = NativeNames ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = SelfieRequired ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = TranslationRequired ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checktype = writer.WriteObject(Type);
            if (checktype.IsError)
            {
                return checktype;
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
            NativeNames = FlagsHelper.IsFlagSet(Flags, 0);
            SelfieRequired = FlagsHelper.IsFlagSet(Flags, 1);
            TranslationRequired = FlagsHelper.IsFlagSet(Flags, 2);
            var trytype = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase>();
            if (trytype.IsError)
            {
                return ReadResult<IObject>.Move(trytype);
            }
            Type = trytype.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "secureRequiredType";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SecureRequiredType
            {
                Flags = Flags,
                NativeNames = NativeNames,
                SelfieRequired = SelfieRequired,
                TranslationRequired = TranslationRequired
            };
            var cloneType = (CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase?)Type.Clone();
            if (cloneType is null)
            {
                return null;
            }
            newClonedObject.Type = cloneType;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not SecureRequiredType castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (NativeNames != castedOther.NativeNames)
            {
                return true;
            }
            if (SelfieRequired != castedOther.SelfieRequired)
            {
                return true;
            }
            if (TranslationRequired != castedOther.TranslationRequired)
            {
                return true;
            }
            if (Type.Compare(castedOther.Type))
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}