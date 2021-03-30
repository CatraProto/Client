using System;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using CatraProto.TL;

namespace CatraProto.Client.TL.Methods.CloudChats
{
    public partial class Messages
    {
        private Connection _connection;

        internal Messages(Connection connection)
        {
            _connection = connection;
        }

        public async Task<UpdatesBase> SendMessage()
        {
            var obj = new SendMessage()
            {
                //robe
            }.ToArray(MergedProvider.DefaultInstance);
            //var requestResult = await _connection.SendEncryptedRequest(obj);
            //return requestResult.ToObject<UpdatesBase>(MergedProvider.DefaultInstance);
            throw new NotImplementedException();
        }
    }
}