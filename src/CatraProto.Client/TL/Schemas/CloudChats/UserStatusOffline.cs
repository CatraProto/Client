using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UserStatusOffline : CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 9203775; }

        [Newtonsoft.Json.JsonProperty("was_online")]
        public int WasOnline { get; set; }


#nullable enable
        public UserStatusOffline(int wasOnline)
        {
            WasOnline = wasOnline;
        }
#nullable disable
        internal UserStatusOffline()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(WasOnline);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trywasOnline = reader.ReadInt32();
            if (trywasOnline.IsError)
            {
                return ReadResult<IObject>.Move(trywasOnline);
            }

            WasOnline = trywasOnline.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "userStatusOffline";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UserStatusOffline();
            newClonedObject.WasOnline = WasOnline;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UserStatusOffline castedOther)
            {
                return true;
            }

            if (WasOnline != castedOther.WasOnline)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}