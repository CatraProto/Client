using System.Text;
using CatraProto.TL.Generator.DeclarationInfo;
using CatraProto.TL.Generator.Objects.Types.Interfaces;

namespace CatraProto.TL.Generator.Objects.Types.InternalTypes
{
    public class RandomId : TypeBase
    {
        private string _bindTo;

        public RandomId(string bindTo = null)
        {
            _bindTo = bindTo;
            Namespace = new Namespace("long", false);
            NamingInfo = "long";
            TypeInfo.IsNaked = true;
            TypeInfo.IsBare = true;
        }

        public override NamingInfo GetFinalParameterName(Parameter parameter)
        {
            if (parameter.HasFlag && !parameter.VectorInfo.IsVector)
            {
                return parameter.NamingInfo.CamelCaseName + ".Value";
            }

            return parameter.NamingInfo;
        }

        public override void WriteBaseParameters(StringBuilder stringBuilder, bool isAbstract = false)
        {
        }

        public override void WriteMethodBeforeCall(StringBuilder builder, Parameter parameter, string returnType)
        {
            builder.AppendLine($"if({parameter.NamingInfo.CamelCaseName} is null){{");
            if (parameter.VectorInfo.IsVector)
            {
                if (_bindTo is not null)
                {
                    builder.AppendLine($"{parameter.NamingInfo.CamelCaseName} = new List<long>();");
                    builder.AppendLine($"for (var i = 0; i < {_bindTo}.Count; i++){{");
                    builder.AppendLine($"{parameter.NamingInfo.CamelCaseName}.Add(_client.RandomIdHandler.GetNextId());");
                    builder.AppendLine("}");
                }
            }
            else
            {
                builder.AppendLine($"{parameter.NamingInfo.CamelCaseName} = _client.RandomIdHandler.GetNextId();");
            }

            builder.AppendLine("}");
        }
    }
}