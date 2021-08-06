namespace CatraProto.Client.Async.Loops.Interfaces
{
    public interface IState<out T> where T : System.Enum
    {
        public T GetCurrentState();
    }
}