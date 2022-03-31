using System;
using System.Collections.Generic;
using System.Linq;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CatraProto.Client.TL
{
    public static class TlExtensions
    {
        public static string ToJson(this IObject obj, Formatting formatting = Formatting.Indented)
        {
            return JsonConvert.SerializeObject(obj, formatting);
        }
    }
}