using System;

namespace CatraProto.Client.Tasks.BackgroundTasks.Routers
{
    public class BackgroundTaskRouter<T>
    {
        public int Id { get; }
        public delegate void TaskCompleted(int Id, T result);
        public delegate void ExceptionThrown(int Id, Exception exception);
        public TaskCompleted OnTaskCompleted;
        private ExceptionThrown OnExceptionThrown;
        public BackgroundTaskRouter(int Id, TaskCompleted taskCompletedAction, ExceptionThrown taskExceptionThrown)
        {
            this.Id = Id;
            OnTaskCompleted += taskCompletedAction;
            OnExceptionThrown += taskExceptionThrown;
        }

        public void RouterTaskCompleted(T result)
        {
            OnTaskCompleted(Id, result);
        }

        public void RouterExceptionThrown(Exception e)
        {
            OnExceptionThrown(Id, e);
        }
    }
}
