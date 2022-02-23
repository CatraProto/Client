using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

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