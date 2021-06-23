using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class MaskCoords : MaskCoordsBase
    {
        public static int ConstructorId { get; } = -1361650766;
        public override int N { get; set; }
        public override double X { get; set; }
        public override double Y { get; set; }
        public override double Zoom { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(N);
            writer.Write(X);
            writer.Write(Y);
            writer.Write(Zoom);
        }

        public override void Deserialize(Reader reader)
        {
            N = reader.Read<int>();
            X = reader.Read<double>();
            Y = reader.Read<double>();
            Zoom = reader.Read<double>();
        }
    }
}