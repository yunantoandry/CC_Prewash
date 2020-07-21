using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace TransportServices
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureService.Configure();
            
            //HostFactory.Run(
            //    host =>
            //    {

            //        //host.ConstructUsing(s => new MyService());
            //        //host.WhenStarted(s => s.Start());
            //        //host.WhenStopped(s => s.Stop());

            //        //Setup Account that window service use to run.
            //       // host.RunAsLocalSystem();
            //        host.SetServiceName("MyWindowServiceWithTopshelf");
            //        host.SetDisplayName("MyWindowServiceWithTopshelf");
            //        host.SetDescription("My .Net windows service with Topshelf");
            //        host.StartAutomatically();
            //        host.Service<Service>();
            //    }
            //    );


        }
    }
}
