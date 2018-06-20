using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace WebJob.NS1102
{
    public class Program
    {
        static void Main()
        {
            var config = new JobHostConfiguration();
            var host = new JobHost(config);
            host.RunAndBlock();
        }
    }
}
