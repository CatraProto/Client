namespace CatraProto.Client.Database
{
    public class StructureParameter
    {
        public bool CanBeNull { get; }
        public string Name { get; }
        public DataTypes DataType { get; }
        public bool IsPrimary { get; }

        public StructureParameter(DataTypes dataType, string name, bool isPrimary, bool canBeNull)
        {
            DataType = dataType;
            Name = name;
            IsPrimary = isPrimary;
            CanBeNull = canBeNull;
        }
    }
}