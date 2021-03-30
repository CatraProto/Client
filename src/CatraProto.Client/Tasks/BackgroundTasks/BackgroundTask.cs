using System;
using System.Threading.Tasks;
using CatraProto.Client.Tasks.BackgroundTasks.Routers;

namespace CatraProto.Client.Tasks.BackgroundTasks
{
    public static class BackgroundTask
    {
        public static Task<int> Start<T>(Task<T> action) => Start(action, DefaultOnCompleted, DefaultExceptionHandler);
        public static async Task<int> Start<T>(Task<T> action, BackgroundTaskRouter<T>.TaskCompleted onTaskCompleted, BackgroundTaskRouter<T>.ExceptionThrown exceptionHandler, TaskCreationOptions options = TaskCreationOptions.None)
        {
            var router = new BackgroundTaskRouter<T>(action.Id, onTaskCompleted, exceptionHandler);
            await Task.Factory.StartNew(async () =>
            {
                try
                {
                    var result = await action;
                    router.RouterTaskCompleted(result);
                }
                catch (Exception e)
                {
                    router.RouterExceptionThrown(e);
                }
            },
            options); 
            return action.Id;
        }

        public static Task<int> Start(Task action) => Start(action, DefaultOnCompleted, DefaultExceptionHandler);
        public static async Task<int> Start(Task action, BackgroundTaskRouter.TaskCompleted onTaskCompleted, BackgroundTaskRouter.ExceptionThrown exceptionHandler, TaskCreationOptions options = TaskCreationOptions.None)
        {
            var router = new BackgroundTaskRouter(action.Id, onTaskCompleted, exceptionHandler);
            await Task.Factory.StartNew(async () =>
            {
                try
                {
                    await action;
                    router.SetCompleted();
                }
                catch (Exception e)
                {
                    router.SetException(e);
                }
            },
            options);
            return action.Id;
        }

        public static void DefaultOnCompleted<T>(int id, T result)
        {
        }

        public static void DefaultOnCompleted(int id)
        {
        }

        public static void DefaultExceptionHandler(int id, Exception e)
        {
        }

        public static Task<int> RunBackground(this Task task) => Start(task);
        public static Task<int> RunBackground<T>(this Task<T> task) => Start(task);

        public static Task<int> RunBackground(this Task task, BackgroundTaskRouter.TaskCompleted onTaskCompleted, BackgroundTaskRouter.ExceptionThrown exceptionHandler, TaskCreationOptions options = TaskCreationOptions.None) => Start(task, onTaskCompleted, exceptionHandler, options);
        public static Task<int> RunBackground<T>(this Task<T> task, BackgroundTaskRouter.TaskCompleted onTaskCompleted, BackgroundTaskRouter.ExceptionThrown exceptionHandler, TaskCreationOptions options = TaskCreationOptions.None) => Start(task, onTaskCompleted, exceptionHandler, options);
    }
}
