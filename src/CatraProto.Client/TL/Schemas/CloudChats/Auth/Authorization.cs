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
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class Authorization : CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase
    {
        [Flags]
        public enum FlagsEnum
        {
            SetupPasswordRequired = 1 << 1,
            OtherwiseReloginDays = 1 << 1,
            TmpSessions = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 872119224; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("setup_password_required")]
        public bool SetupPasswordRequired { get; set; }

        [Newtonsoft.Json.JsonProperty("otherwise_relogin_days")]
        public int? OtherwiseReloginDays { get; set; }

        [Newtonsoft.Json.JsonProperty("tmp_sessions")]
        public int? TmpSessions { get; set; }

        [Newtonsoft.Json.JsonProperty("user")]
        public CatraProto.Client.TL.Schemas.CloudChats.UserBase User { get; set; }


#nullable enable
        public Authorization(CatraProto.Client.TL.Schemas.CloudChats.UserBase user)
        {
            User = user;

        }
#nullable disable
        internal Authorization()
        {
        }

        public override void UpdateFlags()
        {
            Flags = SetupPasswordRequired ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = OtherwiseReloginDays == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = TmpSessions == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt32(OtherwiseReloginDays.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(TmpSessions.Value);
            }

            var checkuser = writer.WriteObject(User);
            if (checkuser.IsError)
            {
                return checkuser;
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
            SetupPasswordRequired = FlagsHelper.IsFlagSet(Flags, 1);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryotherwiseReloginDays = reader.ReadInt32();
                if (tryotherwiseReloginDays.IsError)
                {
                    return ReadResult<IObject>.Move(tryotherwiseReloginDays);
                }
                OtherwiseReloginDays = tryotherwiseReloginDays.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trytmpSessions = reader.ReadInt32();
                if (trytmpSessions.IsError)
                {
                    return ReadResult<IObject>.Move(trytmpSessions);
                }
                TmpSessions = trytmpSessions.Value;
            }

            var tryuser = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
            if (tryuser.IsError)
            {
                return ReadResult<IObject>.Move(tryuser);
            }
            User = tryuser.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "auth.authorization";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new Authorization
            {
                Flags = Flags,
                SetupPasswordRequired = SetupPasswordRequired,
                OtherwiseReloginDays = OtherwiseReloginDays,
                TmpSessions = TmpSessions
            };
            var cloneUser = (CatraProto.Client.TL.Schemas.CloudChats.UserBase?)User.Clone();
            if (cloneUser is null)
            {
                return null;
            }
            newClonedObject.User = cloneUser;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not Authorization castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (SetupPasswordRequired != castedOther.SetupPasswordRequired)
            {
                return true;
            }
            if (OtherwiseReloginDays != castedOther.OtherwiseReloginDays)
            {
                return true;
            }
            if (TmpSessions != castedOther.TmpSessions)
            {
                return true;
            }
            if (User.Compare(castedOther.User))
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}