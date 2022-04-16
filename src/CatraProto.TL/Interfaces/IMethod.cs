namespace CatraProto.TL.Interfaces
{
    public interface IMethod : IObject
    {
        public ParserTypes Type { get; init; }
    }
}