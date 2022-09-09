using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class UpdateProfile : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            FirstName = 1 << 0,
            LastName = 1 << 1,
            About = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 2018596725; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("first_name")]
        public string FirstName { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("last_name")]
        public string LastName { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("about")]
        public string About { get; set; }


        public UpdateProfile()
        {
        }

        public void UpdateFlags()
        {
            Flags = FirstName == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = LastName == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = About == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteString(FirstName);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteString(LastName);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteString(About);
            }


            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryfirstName = reader.ReadString();
                if (tryfirstName.IsError)
                {
                    return ReadResult<IObject>.Move(tryfirstName);
                }

                FirstName = tryfirstName.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trylastName = reader.ReadString();
                if (trylastName.IsError)
                {
                    return ReadResult<IObject>.Move(trylastName);
                }

                LastName = trylastName.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryabout = reader.ReadString();
                if (tryabout.IsError)
                {
                    return ReadResult<IObject>.Move(tryabout);
                }

                About = tryabout.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.updateProfile";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new UpdateProfile();
            newClonedObject.Flags = Flags;
            newClonedObject.FirstName = FirstName;
            newClonedObject.LastName = LastName;
            newClonedObject.About = About;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not UpdateProfile castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (FirstName != castedOther.FirstName)
            {
                return true;
            }

            if (LastName != castedOther.LastName)
            {
                return true;
            }

            if (About != castedOther.About)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}