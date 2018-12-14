using CarRentalServiceBL;
using CarRentalServiceDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RESTService" in both code and config file together.
    public class RESTService : IRESTService
    {
        static private CarMethods carMethods = new CarMethods();
        static private CustomerMethods customerMethods = new CustomerMethods();
        static private ReservationMethods reservationMethods = new ReservationMethods();


        public List<Car> GetAvaibleCars()
        {
            return carMethods.GetAvaibleCars();
        }

        public bool AddCar(Car car)
        {
            return carMethods.AddCar(car);
        }

        public List<Customer> GetAllCustomers()
        {
            return customerMethods.GetAllCustomers();
        }

        public void RemoveCustomer(string option, string name)
        {
            customerMethods.RemoveCustomer(option, name);
        }

        public Reservation GetReservationById(int id)
        {
            return reservationMethods.GetReservationById(id);
        }

    }
}
