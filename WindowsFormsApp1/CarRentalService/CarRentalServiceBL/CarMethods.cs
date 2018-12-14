using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalServiceDL;

namespace CarRentalServiceBL
{
    public class CarMethods
    {
        static private CarRentalServicesDBContext _context = new CarRentalServicesDBContext();
        static private ReservationMethods resMethod = new ReservationMethods();

        public CarInfo GetCarById(int id)
        {
            var car = _context.Cars.Where(x => x.Id == id).FirstOrDefault();
            return new CarInfo(car);
        }

        public Car GetCarByRegnum(string regnum)
        {
            return _context.Cars.Where(x => x.Regnumber == regnum).FirstOrDefault();
        }

        public bool AddCar(Car car)
        {
            try
            {
                _context.Cars.Add(car);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
        }

        public bool RemoveCar(string regnum)
        {
            try
            {
                var car = _context.Cars.Where(x => x.Regnumber == regnum).First();
                _context.Cars.Remove(car);
                //_context.Entry(idForCar).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
                throw e;
            }
        }


        public bool UpdateCar(Car car)
        {
            try
            {
                //Removing the old car
                var oldCar = _context.Cars.Where(x => x.Regnumber == car.Regnumber).FirstOrDefault();
                _context.Cars.Remove(oldCar);
                //Input new updated car
                if (AddCar(car))
                {
                    _context.SaveChanges();
                    return true;
                }
                return true;

            }
            catch
            {
                return false;
            }
        }


        /*public List<Car> GetAvaibleCars(DateTime start) // ORIGINAL METOD
        {
            //Get free cars
            var allInUseCars = _context.Reservations.Select(x => x.CarId).ToList();
            List<Car> allAvaibleCars = new List<Car>();
            foreach (var car in _context.Cars.Where(x => x.Id > 0).ToList())
            {
                allAvaibleCars.Add(_context.Cars.Where(x => x.Id == car.Id).First());     //     HAR ÄNDRAT FRÅN != TIL ==
            }
            if (allAvaibleCars.Any())
            {
                return allAvaibleCars;
            }
            //Get booked cars
            else
            {
                var avaibleCars = _context.Reservations.Where(x => x.EndDate < start).ToList();
                if (avaibleCars.Any())
                {
                    foreach (var reservations in avaibleCars)
                    {
                        return _context.Cars.Where(x => x.Id == reservations.Id).ToList();
                    }
                }
            }
            return new List<Car>();
        }*/

        public List<Car> GetAvaibleCars()
        {

            //Get free cars
            //start.ToShortDateString();

            var allInUseCars = _context.Reservations.Where(x => (x.CarId > 0) && (x.Returned == false)).ToList();

            var allAvailableCars = _context.Cars.ToList();

            foreach (var item in allInUseCars)
            {
                allAvailableCars.Remove(item.Car);
            }



            return allAvailableCars;
        }

        
    }
}
