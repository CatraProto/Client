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