using System;
using System.Linq;
using CatraProto.TL.Generator.Settings;

namespace CatraProto.TL.Generator.Objects
{
    public class Namespace
    {
        private string[] _arrayNamespace = Array.Empty<string>();
        private string _fullNamespace = "";
        public string Class => _arrayNamespace[^1];
        public string FullNamespace
        {
            get => _fullNamespace;

            set
            {
                _arrayNamespace = value.Split('.');
                _fullNamespace = value;
            }
        }
        
        public string[] FullNamespaceArray
        {
            get => _arrayNamespace;

            set
            {
                var temp = "";
                for (var i = 0; i < _arrayNamespace.Length; i++)
                {
                    var item = _arrayNamespace[i];
                    temp += item;
                    if (i < _arrayNamespace.Length - 1) temp += ".";
                }

                _arrayNamespace = value;
                _fullNamespace = temp;
            }
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
                var clone = (string[]) _arrayNamespace.Clone();
                var list = clone.ToList();
                list.RemoveAt(clone.Length - 1);
                return list.ToArray();
            }
        }
        
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
            return Equals((Namespace) obj);
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