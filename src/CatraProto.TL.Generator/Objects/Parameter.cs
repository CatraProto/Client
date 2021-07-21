using System;
using System.Text.RegularExpressions;
using CatraProto.TL.Generator.CodeGeneration;
using CatraProto.TL.Generator.DeclarationInfo;
using CatraProto.TL.Generator.Objects.Types.Interfaces;

namespace CatraProto.TL.Generator.Objects
{
    public class Parameter
    {
        public bool HasFlag
        {
            get => Flag != null;
        }
        
        public Flag Flag { get; set; }
        public NamingInfo NamingInfo { get; set; } = new NamingInfo();
        public TypeBase Type { get; set; }
        public VectorInfo VectorInfo { get; set; } = new VectorInfo();

        public bool IsCommon { get; set; }


        public static Parameter Create(string parameter)
        {
            var instance = new Parameter();
            var split = parameter.Split(":");
            instance.NamingInfo = split[0];
            if (FindFlag(split[1], out split[1], out var flag))
            {
                instance.Flag = flag;
            }

            var isNaked = FindNaked(split[1], out split[1]);
            instance.Type = instance.FindTypes(split[1]);
            instance.Type.TypeInfo.IsNaked = isNaked;
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
                VectorInfo.IsVector = true;
                if (found[0][0] == 'v')
                {
                    VectorInfo.IsNaked = true;
                }
            }

            if (found.Length > 2)
            {
                throw new Exception("Multiple types inside types or vectors inside vectors aren't currently supported by the CatraProto.TL.Generator.");
            }

            if (found.Length == 2 && found[0].ToLower() != "vector")
            {
                throw new Exception("Non-vector templated types aren't currently supported by the CatraProto.TL.Generator");
            }

            var toInstantiate = found.Length == 2 ? found[1] : found[0];
            return Tools.CreateType(toInstantiate, new TypeInfo());
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
            return p2 is not null && p1 is not null && p1.NamingInfo.PascalCaseName == p2.NamingInfo.PascalCaseName && p1.Type == p2.Type;
        }

        public static bool operator !=(Parameter p1, Parameter p2)
        {
            return p2 is not null && p1 is not null && (p1.NamingInfo.PascalCaseName != p2.NamingInfo.PascalCaseName || p1.Type != p2.Type);
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