using System;
using System.Text.RegularExpressions;
using CatraProto.TL.Generator.CodeGeneration;
using CatraProto.TL.Generator.Objects.Types.Interfaces;

namespace CatraProto.TL.Generator.Objects
{
	public class Parameter
	{
		private Flag _flag;
		public string Name { get; set; }

		public string InMethodName
		{
			get
			{
				var name = Name;
				var toLower = Name[0].ToString().ToLower();
				return StringTools.FixLanguageWord(toLower + name[1..]);
			}
		}

		public TypeBase Type { get; set; }
		public bool HasFlag { get; set; }
		public bool IsNaked { get; set; }
		public bool IsVector { get; set; }
		public bool IsCommon { get; set; }

		public Flag Flag
		{
			get => _flag;

			set
			{
				_flag = value;
				HasFlag = true;
			}
		}

		public static Parameter Create(string parameter)
		{
			var instance = new Parameter();
			var split = parameter.Split(":");
			instance.Name = StringTools.PascalCase(split[0]);
			if (FindFlag(split[1], out split[1], out var flag))
			{
				instance.Flag = flag;
			}

			if (FindNaked(split[1], out split[1]))
			{
				instance.IsNaked = true;
			}

			instance.Type = instance.FindTypes(split[1]);

			return instance;
		}


		public static bool FindNaked(string type, out string cleanType)
		{
			var match = Regex.Match(type, @"%\w+");
			if (match.Success)
			{
				if (match.Groups[0].Value[0] == '%')
				{
					cleanType = type.Replace("%", string.Empty);
					return true;
				}
			}

			cleanType = type;
			return false;
		}

		public TypeBase FindTypes(string type)
		{
			var found = Regex.IsMatch(type, @"\w+<.+>") ? type.Split("<") : new[] { type };
			if (found.Length == 2)
			{
				found[^1] = found[^1].TrimEnd('>');
				IsVector = true;
			}

			if (found.Length > 2)
			{
				throw new Exception(
					"Multiple types inside types or vectors inside vectors aren't currently supported by the CatraProto.TL.Generator.");
			}

			if (found.Length == 2 && found[0].ToLower() != "vector")
			{
				throw new Exception(
					"Non-vector templated types aren't currently supported by the CatraProto.TL.Generator");
			}

			var toInstanciate = found.Length == 2 ? found[1] : found[0];
			return Tools.CreateType(toInstanciate, true);
		}

		public static bool FindFlag(string type, out string cleanType, out Flag flag)
		{
			var match = Regex.Match(type, @"\w+\.[0-9]+\?");
			if (match.Success)
			{
				var matched = match.Groups[0].Value;
				var split = matched.Split(".");
				var flagName = split[0];
				var flagNumber = int.Parse(split[1].Replace("?", ""));
				flag = new Flag(StringTools.PascalCase(flagName), flagNumber);
				cleanType = type.Replace($"{flagName}.{flagNumber.ToString()}?", string.Empty);
				return true;
			}

			cleanType = type;
			flag = null;
			return false;
		}


		public static bool operator ==(Parameter p1, Parameter p2)
		{
			return p2 is not null && p1 is not null && p1.Name == p2.Name && p1.Type == p2.Type;
		}

		public static bool operator !=(Parameter p1, Parameter p2)
		{
			return p2 is not null && p1 is not null && (p1.Name != p2.Name || p1.Type != p2.Type);
		}

		protected bool Equals(Parameter other)
		{
			return other == this;
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

			return Equals((Parameter)obj);
		}
	}
}