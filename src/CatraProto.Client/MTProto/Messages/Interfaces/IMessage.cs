using System.Threading;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.MTProto.Messages.Interfaces
{
    interface IMessage
    {
        public bool IsEncrypted { get; set; }
        public IObject Body { get; set; }
    }
}