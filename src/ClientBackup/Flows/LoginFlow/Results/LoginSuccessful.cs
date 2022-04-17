using CatraProto.Client.Flows.LoginFlow.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;

namespace CatraProto.Client.Flows.LoginFlow.Results
{
    public class LoginSuccessful : ILoginResult
    {
        public User LoggedUser { get; }

        internal LoginSuccessful(User loggedUser)
        {
            LoggedUser = loggedUser;
        }
    }
}