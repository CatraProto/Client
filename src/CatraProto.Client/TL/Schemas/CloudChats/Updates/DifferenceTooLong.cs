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
    public partial class DifferenceTooLong : CatraProto.Client.TL.Schemas.CloudChats.Updates.DifferenceBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1258196845; }

        [Newtonsoft.Json.JsonProperty("pts")] public int Pts { get; set; }


#nullable enable
        public DifferenceTooLong(int pts)
        {
            Pts = pts;
        }
#nullable disable
        internal DifferenceTooLong()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Pts);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypts = reader.ReadInt32();
            if (trypts.IsError)
            {
                return ReadResult<IObject>.Move(trypts);
            }

            Pts = trypts.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updates.differenceTooLong";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new DifferenceTooLong();
            newClonedObject.Pts = Pts;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not DifferenceTooLong castedOther)
            {
                return true;
            }

            if (Pts != castedOther.Pts)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}