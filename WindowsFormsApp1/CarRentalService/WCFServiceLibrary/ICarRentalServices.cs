using CarRentalServiceDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICarRentalService" in both code and config file together.
    [ServiceContract]
    public interface ICarRentalServices
    {
        /////////////////////////////////////// Car Methods
        ///
        //[OperationContract(ProtectionLevel = ProtectionLevel.Sign)]
        CarInfo GetCarById(CarRequest manager);

        [OperationContract]
        Car GetCarByRegnum(string regnum);

        [OperationContract]
        bool AddCar(Car car);

        [OperationContract]
        bool RemoveCar(string regnum);

        [OperationContract]
        bool UpdateCar(Car car);

        [OperationContract]
        List<Car> GetAvaibleCars();

        /////////////////////////////////////////// Customer Methods
        [OperationContract(ProtectionLevel = ProtectionLevel.None)]
        Customer GetCustomerById(int id);

        [OperationContract]
        Customer GetCustomer(string option, string term);

        [OperationContract]
        List<Customer> GetAllCustomers();

        [OperationContract]
        void AddCustomer(Customer newCust);

        [OperationContract]
        void RemoveCustomer(string option, string name);

        [OperationContract]
        void ChangeCustomer(Customer customer);

        //////////////////////////////////////////////////// Reservation Methods
        [OperationContract]
        Reservation GetReservationById(int id);

        [OperationContract]
        void AddReservation(Reservation reservation);

        [OperationContract]
        List<Reservation> GetReservationByString(string option, string term);

        [OperationContract]
        List<Reservation> GetReservationByDate(DateTime startDate, DateTime endDate);

        [OperationContract]
        void RemoveReservation(int id);

    }


}
