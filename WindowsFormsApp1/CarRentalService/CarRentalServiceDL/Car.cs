using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace CarRentalServiceDL
{
    [DataContract]
    public class Car
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Brand { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        [Required]
        public string Regnumber { get; set; }
    }

    [MessageContract(IsWrapped = true,
        WrapperName = "CarInformation",
        WrapperNamespace = "http://mcroland/Car")]
    public class CarInfo
    {
        public CarInfo() { }
        public CarInfo(Car car)
        {
            this.Id = car.Id;
            this.Brand = car.Brand;
            this.Model = car.Model;
            this.Year = car.Year;
            this.Regnumber = car.Regnumber;
        }

        [MessageBodyMember(Order = 1, Namespace = "http://mcroland/Car")]
        public int Id { get; set; }
        [MessageBodyMember(Order = 2, Namespace = "http://mcroland/Car")]
        public string Brand { get; set; }
        [MessageBodyMember(Order = 3, Namespace = "http://mcroland/Car")]
        public string Model { get; set; }
        [MessageBodyMember(Order = 4, Namespace = "http://mcroland/Car")]
        public int Year { get; set; }
        [MessageBodyMember(Order = 5, Namespace = "http://mcroland/Car")]
        public string Regnumber { get; set; }
    }

    [MessageContract(IsWrapped = true,
        WrapperName = "CarRequestObject",
        WrapperNamespace = "http://mcroland/Car")]
    public class CarRequest
    {
        [MessageBodyMember(Order = 1, Namespace = "http://mcroland/Car")]
        public string LicenseKey { get; set; }
        [MessageBodyMember(Order = 2, Namespace = "http://mcroland/Car")]
        public int Id { get; set; }
    }
}
    