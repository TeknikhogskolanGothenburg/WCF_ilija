using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using CarRentalServiceDL;

namespace CarRentalServiceHost
{
    class Program
    {
        

        static void Main(string[] args)
        {

            using (ServiceHost host = new ServiceHost(typeof(WCFServiceLibrary.CarRentalServices)))
            {
                host.Open();
                Console.WriteLine("\n" + "Host started @ " + DateTime.Now.ToString());
                Console.ReadLine();
            }


            Console.ReadKey();

            
        }
    }
}
