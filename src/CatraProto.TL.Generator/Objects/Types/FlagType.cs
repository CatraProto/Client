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

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using CatraProto.TL.Generator.Objects.Types.Interfaces;

namespace CatraProto.TL.Generator.Objects.Types
{
	class FlagType : TypeBase
	{
		public FlagType()
		{
			NamingInfo = "flag";
			TypeInfo.IsBare = true;
		}

		public override void WriteParameter(StringBuilder stringBuilder, Parameter parameter, string customTypeName = null, bool isAbstract = false)
		{
			stringBuilder.AppendLine($"\n[Newtonsoft.Json.JsonIgnore]\n{StringTools.TwoTabs}{GetParameterAccessibility(parameter, isAbstract)} int {parameter.NamingInfo.PascalCaseName} {{ get; set; }}");
		}


		public override void WriteSerializer(StringBuilder stringBuilder, Parameter parameter)
		{
			stringBuilder.AppendLine($"{StringTools.ThreeTabs}UpdateFlags();");
            base.WriteSerializer(stringBuilder, parameter);
		}

		public override void WriteBaseParameters(StringBuilder stringBuilder, bool allowOverrides = false)
		{
			throw new NotSupportedException();
		}
	}
}