using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FunctionNS901
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([QueueTrigger("myqueue")] Notification message, TraceWriter log)
        {
            var jsonMsg = JsonConvert.SerializeObject(message);
            log.Info(jsonMsg);
        }
    }

    public class Notification
    {
        public string Target { get; set; }
        public Guid Uid { get; set; }
        public string Topic { get; set; }
        public string HubSecret { get; set; }
        public DateTime Created { get; set; }
        public DateTime? FirstSentAt { get; set; }
        public IEnumerable<NotificationItem> Payload { get; set; }
    }

    public class NotificationItem
    {
        public string Type { get; set; }
        public object Data { get; set; }
    }
}
