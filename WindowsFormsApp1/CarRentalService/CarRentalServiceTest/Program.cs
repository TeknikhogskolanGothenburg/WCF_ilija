using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CarRentalServiceDL;
using System.ServiceModel;


namespace CarRentalServiceTest
{
    class Program
    {
        /*static private CarRentalServicesDBContext _context = new CarRentalServicesDBContext();
        static private CarMethods carMethods = new CarMethods();
        static private CustomerMethods customerMethods = new CustomerMethods();
        static private ReservationMethods reservationMethods = new ReservationMethods();*/

        // cd \Users\Ilija\Documents\Visual Studio 2017\Projects\1GruppCarRental\CarRentalService\CarRentalServiceTest\bin\Debug

        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(WCFServiceLibrary.CarRentalServices)))
            {
                host.Open();
                Console.WriteLine("Host started @ " + DateTime.Now.ToString());
                Console.ReadLine();
            }

        }
    }
}
