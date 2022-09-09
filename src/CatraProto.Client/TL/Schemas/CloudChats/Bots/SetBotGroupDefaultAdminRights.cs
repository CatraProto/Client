using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Bots
{
    public partial class SetBotGroupDefaultAdminRights : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1839281686; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("admin_rights")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase AdminRights { get; set; }


#nullable enable
        public SetBotGroupDefaultAdminRights(CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase adminRights)
        {
            AdminRights = adminRights;
        }
#nullable disable

        internal SetBotGroupDefaultAdminRights()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkadminRights = writer.WriteObject(AdminRights);
            if (checkadminRights.IsError)
            {
                return checkadminRights;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryadminRights = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase>();
            if (tryadminRights.IsError)
            {
                return ReadResult<IObject>.Move(tryadminRights);
            }

            AdminRights = tryadminRights.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "bots.setBotGroupDefaultAdminRights";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SetBotGroupDefaultAdminRights();
            var cloneAdminRights = (CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase?)AdminRights.Clone();
            if (cloneAdminRights is null)
            {
                return null;
            }

            newClonedObject.AdminRights = cloneAdminRights;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SetBotGroupDefaultAdminRights castedOther)
            {
                return true;
            }

            if (AdminRights.Compare(castedOther.AdminRights))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}