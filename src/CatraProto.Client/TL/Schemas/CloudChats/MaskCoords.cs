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
    public partial class MaskCoords : CatraProto.Client.TL.Schemas.CloudChats.MaskCoordsBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1361650766; }

        [Newtonsoft.Json.JsonProperty("n")] public sealed override int N { get; set; }

        [Newtonsoft.Json.JsonProperty("x")] public sealed override double X { get; set; }

        [Newtonsoft.Json.JsonProperty("y")] public sealed override double Y { get; set; }

        [Newtonsoft.Json.JsonProperty("zoom")] public sealed override double Zoom { get; set; }


#nullable enable
        public MaskCoords(int n, double x, double y, double zoom)
        {
            N = n;
            X = x;
            Y = y;
            Zoom = zoom;
        }
#nullable disable
        internal MaskCoords()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(N);

            writer.WriteDouble(X);

            writer.WriteDouble(Y);

            writer.WriteDouble(Zoom);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryn = reader.ReadInt32();
            if (tryn.IsError)
            {
                return ReadResult<IObject>.Move(tryn);
            }

            N = tryn.Value;
            var tryx = reader.ReadDouble();
            if (tryx.IsError)
            {
                return ReadResult<IObject>.Move(tryx);
            }

            X = tryx.Value;
            var tryy = reader.ReadDouble();
            if (tryy.IsError)
            {
                return ReadResult<IObject>.Move(tryy);
            }

            Y = tryy.Value;
            var tryzoom = reader.ReadDouble();
            if (tryzoom.IsError)
            {
                return ReadResult<IObject>.Move(tryzoom);
            }

            Zoom = tryzoom.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "maskCoords";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MaskCoords();
            newClonedObject.N = N;
            newClonedObject.X = X;
            newClonedObject.Y = Y;
            newClonedObject.Zoom = Zoom;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MaskCoords castedOther)
            {
                return true;
            }

            if (N != castedOther.N)
            {
                return true;
            }

            if (X != castedOther.X)
            {
                return true;
            }

            if (Y != castedOther.Y)
            {
                return true;
            }

            if (Zoom != castedOther.Zoom)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}