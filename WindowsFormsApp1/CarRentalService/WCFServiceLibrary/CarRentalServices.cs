using CarRentalServiceBL;
using CarRentalServiceDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CarRentalService" in both code and config file together.
    public class CarRentalServices : ICarRentalServices
    {
        static private CarMethods carMethods = new CarMethods();
        static private CustomerMethods customerMethods = new CustomerMethods();
        static private ReservationMethods reservationMethods = new ReservationMethods();

        //////////////////////////////////////////////// CAR METHODS
        public CarInfo GetCarById(CarRequest manager)
        {
            if (manager.LicenseKey != "hemligt")
            {
                throw new WebFaultException<string>(
                    "Wrong license key", HttpStatusCode.Forbidden);
            }
            else
            {
                return carMethods.GetCarById(manager.Id);
            }
        }

        public Car GetCarByRegnum(string regnum)
        {
            return carMethods.GetCarByRegnum(regnum);
        }

        public bool AddCar(Car car)
        {
            return carMethods.AddCar(car);
        }

        public bool RemoveCar(string regnum)
        {
            return carMethods.RemoveCar(regnum);
        }

        public bool UpdateCar(Car car)
        {
            return carMethods.UpdateCar(car);
        }

        public List<Car> GetAvaibleCars()
        {
            return carMethods.GetAvaibleCars();
        }

        /////////////////////////////////////////////////// CUSTOMER METHODS
        public Customer GetCustomerById(int id)
        {
            return customerMethods.GetCustomerById(id);
        }

        public Customer GetCustomer(string option, string term)
        {
            return customerMethods.GetCustomer(option, term);
        }

        public List<Customer> GetAllCustomers()
        {          
            return customerMethods.GetAllCustomers();
        }

        public void AddCustomer(Customer newCust)
        {
            customerMethods.AddCustomer(newCust);
        }

        public void RemoveCustomer(string option, string name)
        {
            customerMethods.RemoveCustomer(option, name);
        }

        public void ChangeCustomer(Customer customer)
        {
            customerMethods.ChangeCustomer(customer);
        }

        /////////////////////////////////////////////////////// Reservation Methods
        public Reservation GetReservationById(int id)
        {
            return reservationMethods.GetReservationById(id);
        }

        public void AddReservation(Reservation reservation)
        {
            reservationMethods.AddReservation(reservation);
        }

        public List<Reservation> GetReservationByString(string option, string term)
        {
            return reservationMethods.GetReservationByString(option, term);
        }

        public List<Reservation> GetReservationByDate(DateTime startDate, DateTime endDate)
        {
            return reservationMethods.GetReservationByDate(startDate, endDate);
        }

        public void RemoveReservation(int id)
        {
            reservationMethods.RemoveReservation(id);
        }

    }
}
