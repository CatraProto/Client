using System.Text;
using CatraProto.TL.Generator.Objects.Interfaces;

namespace CatraProto.TL.Generator.Objects
{
    
    internal class Method : Object
    {
        public bool ReturnsVector { get; set; }

        public void WriteMethod(StringBuilder builder)
        {
            var args = new StringBuilder();
            string returnType;
            if (Type.IsBare)
            {
                returnType = ReturnsVector ? "IList<" + Type.Name + ">" : Type.Name;
            }
            else
            {
                returnType = ReturnsVector ? "IList<" + Type.Namespace.FullNamespace + ">" : Type.Namespace.FullNamespace;   
            }
            
            for (var index = 0; index < Parameters.Count; index++)
            {
                var parameter = Parameters[index];
                parameter.Type.WriteMethodParameter(args, parameter);
                if (index < Parameters.Count - 1)
                {
                    args.Append(',');
                } 
            }

            builder.AppendLine($"{StringTools.TwoTabs}public async Task<{returnType}> {Name}({args})\n{StringTools.TwoTabs}{{");
            builder.AppendLine($"{StringTools.ThreeTabs}var request = new {Namespace.FullNamespace}()\n{StringTools.ThreeTabs}{{");
            foreach (var parameter in Parameters)
            {
                builder.AppendLine($"{StringTools.FourTabs}{parameter.Name} = {parameter.InMethodName},");
            }
            builder.AppendLine($"{StringTools.ThreeTabs}}}");
            builder.AppendLine($"{StringTools.ThreeTabs}BLA BLA send Request");
            builder.AppendLine("}");
        }
    }
}