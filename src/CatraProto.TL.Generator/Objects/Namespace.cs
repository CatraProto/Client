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
using System.Linq;
using CatraProto.TL.Generator.Settings;

namespace CatraProto.TL.Generator.Objects
{
	public class Namespace
	{
		private string[] _arrayNamespace = Array.Empty<string>();

		public Namespace(string fullNamespace, bool addDefault = true)
		{
			var ns = addDefault ? Configuration.Namespace + "." + fullNamespace : fullNamespace;
			FullNamespace = StringTools.PascalCase(ns);
		}

		public string Class
		{
			get => _arrayNamespace[^1];
			set => _arrayNamespace[^1] = value;
		}

		public string FullNamespace
		{
			get => ArrayToString(_arrayNamespace);
			set => _arrayNamespace = value.Split('.');
		}

		public string[] FullNamespaceArray
		{
			get => _arrayNamespace;
			set => _arrayNamespace = value;
		}

		public string PartialNamespace
		{
			get
			{
				var temp = "";
				for (var i = 0; i < _arrayNamespace.Length - 1; i++)
				{
					var item = _arrayNamespace[i];
					temp += item;
					if (i < _arrayNamespace.Length - 2)
					{
						temp += ".";
					}
				}

				return temp;
			}
		}

		public string[] PartialNamespaceArray
		{
			get
			{
				var clone = (string[])_arrayNamespace.Clone();
				var list = clone.ToList();
				list.RemoveAt(clone.Length - 1);
				return list.ToArray();
			}
		}

		public string this[Index index]
		{
			get => _arrayNamespace[index];
			set => _arrayNamespace[index] = value;
		}

		protected bool Equals(Namespace other)
		{
			return other.FullNamespace == FullNamespace;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}

			if (ReferenceEquals(this, obj))
			{
				return true;
			}

			if (obj.GetType() != GetType())
			{
				return false;
			}

			return Equals((Namespace)obj);
		}

		public static string ArrayToString(string[] array)
		{
			var final = "";
			for (var index = 0; index < array.Length; index++)
			{
				var s = array[index];
				if (index != 0)
				{
					final += ".";
				}

				final += s;
			}

			return final;
		}

		public static bool operator ==(Namespace ns1, Namespace ns2)
		{
			return ns2 is not null && ns1 is not null && ns1.FullNamespace == ns2.FullNamespace;
		}

		public static bool operator !=(Namespace ns1, Namespace ns2)
		{
			return ns2 is not null && ns1 is not null && ns1.FullNamespace != ns2.FullNamespace;
		}
	}
}