using System;

namespace CatraProto.Client.Tasks.BackgroundTasks.Routers
{
    public class BackgroundTaskRouter
    {
        public int Id { get; }
        public delegate void TaskCompleted(int id);
        public delegate void ExceptionThrown(int id, Exception exception);
        public TaskCompleted OnTaskCompleted;
        public ExceptionThrown OnExceptionThrown;
        public BackgroundTaskRouter(int id, TaskCompleted taskCompletedAction, ExceptionThrown taskExceptionThrown)
        {
            Id = id;
            OnTaskCompleted += taskCompletedAction;
            OnExceptionThrown += taskExceptionThrown;
        }

        public void SetCompleted()
        {
            OnTaskCompleted(Id);
        }

        public void SetException(Exception e)
        {
            OnExceptionThrown(Id, e);
        }
    }
}
