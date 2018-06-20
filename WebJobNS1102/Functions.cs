using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace WebJob.NS1102
{
    public class Functions
    {
        public static void ProcessQueueMessage([QueueTrigger("myqueue")] Notification message, TextWriter log)
        {
            var jsonMsg = JsonConvert.SerializeObject(message);
            log.WriteLine(jsonMsg);
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
}
