using CarRentalServiceDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRESTService" in both code and config file together.
    [ServiceContract]
    public interface IRESTService
    {
        [OperationContract]
        [WebGet(UriTemplate = "GetAvailableCars",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json)]
        List<Car> GetAvaibleCars();

        [OperationContract]
        [WebInvoke(Method = "PUT",
           UriTemplate = "AddCar",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool AddCar(Car car);

        [OperationContract]
        [WebGet(UriTemplate = "GetAllCustomers",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json)]
        List<Customer> GetAllCustomers();

        [OperationContract]
        [WebInvoke(Method = "DELETE",
           UriTemplate = "DeleteCustomer",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        void RemoveCustomer(string option, string name);

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "GetReservation",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Reservation GetReservationById(int id);


    }
}
