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

using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MaskCoords : CatraProto.Client.TL.Schemas.CloudChats.MaskCoordsBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1361650766; }

        [Newtonsoft.Json.JsonProperty("n")]
        public sealed override int N { get; set; }

        [Newtonsoft.Json.JsonProperty("x")]
        public sealed override double X { get; set; }

        [Newtonsoft.Json.JsonProperty("y")]
        public sealed override double Y { get; set; }

        [Newtonsoft.Json.JsonProperty("zoom")]
        public sealed override double Zoom { get; set; }


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
            var newClonedObject = new MaskCoords
            {
                N = N,
                X = X,
                Y = Y,
                Zoom = Zoom
            };
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