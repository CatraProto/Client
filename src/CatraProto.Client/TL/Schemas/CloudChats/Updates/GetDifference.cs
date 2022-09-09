using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
    public partial class GetDifference : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            PtsTotalLimit = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 630429265; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("pts")] public int Pts { get; set; }

        [Newtonsoft.Json.JsonProperty("pts_total_limit")]
        public int? PtsTotalLimit { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("qts")] public int Qts { get; set; }


#nullable enable
        public GetDifference(int pts, int date, int qts)
        {
            Pts = pts;
            Date = date;
            Qts = qts;
        }
#nullable disable

        internal GetDifference()
        {
        }

        public void UpdateFlags()
        {
            Flags = PtsTotalLimit == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(Pts);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(PtsTotalLimit.Value);
            }

            writer.WriteInt32(Date);
            writer.WriteInt32(Qts);

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
            var trypts = reader.ReadInt32();
            if (trypts.IsError)
            {
                return ReadResult<IObject>.Move(trypts);
            }

            Pts = trypts.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryptsTotalLimit = reader.ReadInt32();
                if (tryptsTotalLimit.IsError)
                {
                    return ReadResult<IObject>.Move(tryptsTotalLimit);
                }

                PtsTotalLimit = tryptsTotalLimit.Value;
            }

            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            var tryqts = reader.ReadInt32();
            if (tryqts.IsError)
            {
                return ReadResult<IObject>.Move(tryqts);
            }

            Qts = tryqts.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updates.getDifference";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetDifference();
            newClonedObject.Flags = Flags;
            newClonedObject.Pts = Pts;
            newClonedObject.PtsTotalLimit = PtsTotalLimit;
            newClonedObject.Date = Date;
            newClonedObject.Qts = Qts;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetDifference castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Pts != castedOther.Pts)
            {
                return true;
            }

            if (PtsTotalLimit != castedOther.PtsTotalLimit)
            {
                return true;
            }

            if (Date != castedOther.Date)
            {
                return true;
            }

            if (Qts != castedOther.Qts)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}