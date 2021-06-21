using System;
using System.Linq;
using CatraProto.TL.Generator.Settings;

namespace CatraProto.TL.Generator.Objects
{
    public class Namespace
    {
        public string Class
        {
            get => _arrayNamespace[^1];
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
                    if (i < _arrayNamespace.Length - 2) temp += ".";
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

        private string[] _arrayNamespace = Array.Empty<string>();

        public Namespace(string fullNamespace, bool addDefault = true)
        {
            var ns = addDefault ? Configuration.Namespace + "." + fullNamespace : fullNamespace;
            FullNamespace = StringTools.PascalCase(ns);
        }

        protected bool Equals(Namespace other)
        {
            return other.FullNamespace == FullNamespace;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
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

        public string this[Index index]
        {
            get => _arrayNamespace[index];
            set => _arrayNamespace[index] = value;
        }
    }
}