using MultipleTasks.Service.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleTasks.Service
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Working with Task Queue");

            var messages = new List<string>();
            messages.Add("Message 1");
            messages.Add("Message 2");
            messages.Add("Message 3");
            messages.Add("Message 4");
            messages.Add("Message 5");
            messages.Add("Message 6");
            messages.Add("Message 7");
            messages.Add("Message 8");
            messages.Add("Message 9");
            messages.Add("Message 10");
            messages.Add("Message 11");
            messages.Add("Message 12");

            var task = new TaskQueue(maxParallelizationCount: 3, maxQueueLength: messages.Count());

            foreach (var message in messages)
                task.Queue(() => ProcessService(message));

            await task.Process();
        }

        static async Task ProcessService(string value)
        {
            Console.WriteLine(value);
        }
    }
}
