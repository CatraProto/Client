using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

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

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 2013922064; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("popup")]
        public sealed override bool Popup { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Id { get; set; }

        [Newtonsoft.Json.JsonProperty("text")] public sealed override string Text { get; set; }

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
            var newClonedObject = new TermsOfService();
            newClonedObject.Flags = Flags;
            newClonedObject.Popup = Popup;
            var cloneId = (CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase?)Id.Clone();
            if (cloneId is null)
            {
                return null;
            }

            newClonedObject.Id = cloneId;
            newClonedObject.Text = Text;
            newClonedObject.Entities = new List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();
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

        public override bool Compare(IObject other)
        {
            if (other is not TermsOfService castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Popup != castedOther.Popup)
            {
                return true;
            }

            if (Id.Compare(castedOther.Id))
            {
                return true;
            }

            if (Text != castedOther.Text)
            {
                return true;
            }

            var entitiessize = castedOther.Entities.Count;
            if (entitiessize != Entities.Count)
            {
                return true;
            }

            for (var i = 0; i < entitiessize; i++)
            {
                if (castedOther.Entities[i].Compare(Entities[i]))
                {
                    return true;
                }
            }

            if (MinAgeConfirm != castedOther.MinAgeConfirm)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}