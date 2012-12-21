/* LICENSE
 * From https://github.com/Code52/DownmarkerWPF
 * Licensed under an MS-PL license
 */

using System;
using System.Threading.Tasks;

namespace Proverb.Extensions
{
    public static class TaskExtensions
    {
        public static void PropagateExceptions(this Task task)
        {
            if (task == null)
                throw new ArgumentNullException("task");
            if (!task.IsCompleted)
                throw new InvalidOperationException("The task has not completed yet.");

            if (task.IsFaulted)
                task.Wait();
        }
    }
}
