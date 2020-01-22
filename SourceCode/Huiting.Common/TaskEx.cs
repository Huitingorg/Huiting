using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Huiting.Common
{
    public class TaskEx
    {
        //public static Task<TResult> Run<TResult>(Func<TResult> func)
        //{
        //    return Task.Factory.StartNew<TResult>(func);
        //}

        public static Task Run(Action action)
        {
            var tcs = new TaskCompletionSource<object>();
            ThreadPool.QueueUserWorkItem((obj) =>
            {
                try
                {
                    action();
                    tcs.SetResult(null);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            });
            //new Thread(() =>
            //{
            //    try
            //    {
            //        action();
            //        tcs.SetResult(null);
            //    }
            //    catch (Exception ex)
            //    {
            //        tcs.SetException(ex);
            //    }
            //})
            //{ IsBackground = true }.Start();
            return tcs.Task;
        }

        public static Task<TResult> Run<TResult>(Func<TResult> function)
        {
            var tcs = new TaskCompletionSource<TResult>();
            ThreadPool.QueueUserWorkItem((obj) =>
            {
                try
                {
                    tcs.SetResult(function());
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            });
            //new Thread(() =>
            //{
            //    try
            //    {
            //        tcs.SetResult(function());
            //    }
            //    catch (Exception ex)
            //    {
            //        tcs.SetException(ex);
            //    }
            //})
            //{ IsBackground = true }.Start();
            return tcs.Task;
        }

        public static Task Delay(int milliseconds)
        {
            var tcs = new TaskCompletionSource<object>();
            var timer = new System.Timers.Timer(milliseconds) { AutoReset = false };
            timer.Elapsed += delegate { timer.Dispose(); tcs.SetResult(null); };
            timer.Start();
            return tcs.Task;
        }

    }
}
