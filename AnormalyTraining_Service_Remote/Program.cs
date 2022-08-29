using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace AnormalyTraining_Service_Remote
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            bool isReady, isReady2;
            var mutex = new System.Threading.Mutex(true, "AnomalyTraining_Service", out isReady);
            var mutex2 = new System.Threading.Mutex(true, "AnomalyTraining_Service_Remote", out isReady2);
            if (!isReady || !isReady2)
            {
                return;
            }
            GC.KeepAlive(mutex);
            GC.KeepAlive(mutex2);

#if DEBUG

            Service1 myService = new Service1();
            myService.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
#else

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
