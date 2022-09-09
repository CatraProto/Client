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
    public partial class SecureValue : CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Data = 1 << 0,
            FrontSide = 1 << 1,
            ReverseSide = 1 << 2,
            Selfie = 1 << 3,
            Translation = 1 << 6,
            Files = 1 << 4,
            PlainData = 1 << 5
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 411017418; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("type")] public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase Type { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("data")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecureDataBase Data { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("front_side")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase FrontSide { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("reverse_side")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase ReverseSide { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("selfie")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase Selfie { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("translation")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase> Translation { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("files")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase> Files { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("plain_data")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecurePlainDataBase PlainData { get; set; }

        [Newtonsoft.Json.JsonProperty("hash")] public sealed override byte[] Hash { get; set; }


#nullable enable
        public SecureValue(CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase type, byte[] hash)
        {
            Type = type;
            Hash = hash;
        }
#nullable disable
        internal SecureValue()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Data == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = FrontSide == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = ReverseSide == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = Selfie == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = Translation == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
            Flags = Files == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
            Flags = PlainData == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
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

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkdata = writer.WriteObject(Data);
                if (checkdata.IsError)
                {
                    return checkdata;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checkfrontSide = writer.WriteObject(FrontSide);
                if (checkfrontSide.IsError)
                {
                    return checkfrontSide;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var checkreverseSide = writer.WriteObject(ReverseSide);
                if (checkreverseSide.IsError)
                {
                    return checkreverseSide;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var checkselfie = writer.WriteObject(Selfie);
                if (checkselfie.IsError)
                {
                    return checkselfie;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                var checktranslation = writer.WriteVector(Translation, false);
                if (checktranslation.IsError)
                {
                    return checktranslation;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var checkfiles = writer.WriteVector(Files, false);
                if (checkfiles.IsError)
                {
                    return checkfiles;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                var checkplainData = writer.WriteObject(PlainData);
                if (checkplainData.IsError)
                {
                    return checkplainData;
                }
            }


            writer.WriteBytes(Hash);

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
            var trytype = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase>();
            if (trytype.IsError)
            {
                return ReadResult<IObject>.Move(trytype);
            }

            Type = trytype.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trydata = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SecureDataBase>();
                if (trydata.IsError)
                {
                    return ReadResult<IObject>.Move(trydata);
                }

                Data = trydata.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryfrontSide = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase>();
                if (tryfrontSide.IsError)
                {
                    return ReadResult<IObject>.Move(tryfrontSide);
                }

                FrontSide = tryfrontSide.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryreverseSide = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase>();
                if (tryreverseSide.IsError)
                {
                    return ReadResult<IObject>.Move(tryreverseSide);
                }

                ReverseSide = tryreverseSide.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var tryselfie = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase>();
                if (tryselfie.IsError)
                {
                    return ReadResult<IObject>.Move(tryselfie);
                }

                Selfie = tryselfie.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                var trytranslation = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
                if (trytranslation.IsError)
                {
                    return ReadResult<IObject>.Move(trytranslation);
                }

                Translation = trytranslation.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var tryfiles = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
                if (tryfiles.IsError)
                {
                    return ReadResult<IObject>.Move(tryfiles);
                }

                Files = tryfiles.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                var tryplainData = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SecurePlainDataBase>();
                if (tryplainData.IsError)
                {
                    return ReadResult<IObject>.Move(tryplainData);
                }

                PlainData = tryplainData.Value;
            }

            var tryhash = reader.ReadBytes();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }

            Hash = tryhash.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "secureValue";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SecureValue();
            newClonedObject.Flags = Flags;
            var cloneType = (CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase?)Type.Clone();
            if (cloneType is null)
            {
                return null;
            }

            newClonedObject.Type = cloneType;
            if (Data is not null)
            {
                var cloneData = (CatraProto.Client.TL.Schemas.CloudChats.SecureDataBase?)Data.Clone();
                if (cloneData is null)
                {
                    return null;
                }

                newClonedObject.Data = cloneData;
            }

            if (FrontSide is not null)
            {
                var cloneFrontSide = (CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase?)FrontSide.Clone();
                if (cloneFrontSide is null)
                {
                    return null;
                }

                newClonedObject.FrontSide = cloneFrontSide;
            }

            if (ReverseSide is not null)
            {
                var cloneReverseSide = (CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase?)ReverseSide.Clone();
                if (cloneReverseSide is null)
                {
                    return null;
                }

                newClonedObject.ReverseSide = cloneReverseSide;
            }

            if (Selfie is not null)
            {
                var cloneSelfie = (CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase?)Selfie.Clone();
                if (cloneSelfie is null)
                {
                    return null;
                }

                newClonedObject.Selfie = cloneSelfie;
            }

            if (Translation is not null)
            {
                newClonedObject.Translation = new List<CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase>();
                foreach (var translation in Translation)
                {
                    var clonetranslation = (CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase?)translation.Clone();
                    if (clonetranslation is null)
                    {
                        return null;
                    }

                    newClonedObject.Translation.Add(clonetranslation);
                }
            }

            if (Files is not null)
            {
                newClonedObject.Files = new List<CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase>();
                foreach (var files in Files)
                {
                    var clonefiles = (CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase?)files.Clone();
                    if (clonefiles is null)
                    {
                        return null;
                    }

                    newClonedObject.Files.Add(clonefiles);
                }
            }

            if (PlainData is not null)
            {
                var clonePlainData = (CatraProto.Client.TL.Schemas.CloudChats.SecurePlainDataBase?)PlainData.Clone();
                if (clonePlainData is null)
                {
                    return null;
                }

                newClonedObject.PlainData = clonePlainData;
            }

            newClonedObject.Hash = Hash;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not SecureValue castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Type.Compare(castedOther.Type))
            {
                return true;
            }

            if (Data is null && castedOther.Data is not null || Data is not null && castedOther.Data is null)
            {
                return true;
            }

            if (Data is not null && castedOther.Data is not null && Data.Compare(castedOther.Data))
            {
                return true;
            }

            if (FrontSide is null && castedOther.FrontSide is not null || FrontSide is not null && castedOther.FrontSide is null)
            {
                return true;
            }

            if (FrontSide is not null && castedOther.FrontSide is not null && FrontSide.Compare(castedOther.FrontSide))
            {
                return true;
            }

            if (ReverseSide is null && castedOther.ReverseSide is not null || ReverseSide is not null && castedOther.ReverseSide is null)
            {
                return true;
            }

            if (ReverseSide is not null && castedOther.ReverseSide is not null && ReverseSide.Compare(castedOther.ReverseSide))
            {
                return true;
            }

            if (Selfie is null && castedOther.Selfie is not null || Selfie is not null && castedOther.Selfie is null)
            {
                return true;
            }

            if (Selfie is not null && castedOther.Selfie is not null && Selfie.Compare(castedOther.Selfie))
            {
                return true;
            }

            if (Translation is null && castedOther.Translation is not null || Translation is not null && castedOther.Translation is null)
            {
                return true;
            }

            if (Translation is not null && castedOther.Translation is not null)
            {
                var translationsize = castedOther.Translation.Count;
                if (translationsize != Translation.Count)
                {
                    return true;
                }

                for (var i = 0; i < translationsize; i++)
                {
                    if (castedOther.Translation[i].Compare(Translation[i]))
                    {
                        return true;
                    }
                }
            }

            if (Files is null && castedOther.Files is not null || Files is not null && castedOther.Files is null)
            {
                return true;
            }

            if (Files is not null && castedOther.Files is not null)
            {
                var filessize = castedOther.Files.Count;
                if (filessize != Files.Count)
                {
                    return true;
                }

                for (var i = 0; i < filessize; i++)
                {
                    if (castedOther.Files[i].Compare(Files[i]))
                    {
                        return true;
                    }
                }
            }

            if (PlainData is null && castedOther.PlainData is not null || PlainData is not null && castedOther.PlainData is null)
            {
                return true;
            }

            if (PlainData is not null && castedOther.PlainData is not null && PlainData.Compare(castedOther.PlainData))
            {
                return true;
            }

            if (Hash != castedOther.Hash)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}