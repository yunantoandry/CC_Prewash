using Topshelf;
using log4net.Config;

namespace TransportServices
{
    internal class ConfigureService
    {
        internal static void Configure()
        {
            HostFactory.Run(
                configure =>
                {
                    configure.Service<MyService>(
                        service =>
                        {                           
                            service.WhenStarted(s => s.Start());
                            service.WhenStopped(s => s.Stop());
                            service.ConstructUsing(s => new MyService());


                        });
                    //Setup Account that window service use to run.
                    configure.RunAsLocalSystem();
                    //configure.UseLog4Net();
                    configure.SetServiceName("MyWindowServiceWithTopshelf");
                    configure.SetDisplayName("MyWindowServiceWithTopshelf");
                    configure.SetDescription("My .Net windows service with Topshelf");
                }
                );
        }
    }
}