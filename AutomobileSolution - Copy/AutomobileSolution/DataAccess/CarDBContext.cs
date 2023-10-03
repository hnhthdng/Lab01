using AutomobileSolution.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileSolution.DataAccess
{
    public class CarDBContext
    {
        private static List<Car> CarList = new List<Car>()
        {
            new Car
            {
                CarID = 1,
                CarName = "LV",
                Manufacturer = "Honda",
                Price = 30000,
                ReleaseYear = 2021
            },
            new Car
            {
                CarID = 2,
                CarName = "Yamaha",
                Manufacturer = "Ford",
                Price = 3000000,
                ReleaseYear = 2020

            }
        };

        private static CarDBContext instance = null;
        public static readonly object instanceLook = new object();
        private CarDBContext() { }
        public static CarDBContext Instance
        {
            get
            { 
                lock (instanceLook)
                {
                    if(instance == null)
                    {
                        instance = new CarDBContext();
                    }
                    return instance;
                }   
            }
        }

        public List<Car> GetCarList => CarList;
        public Car GetCarById(int carID)
        {
            Car car  = CarList.SingleOrDefault(pro => pro.CarID == carID);
            return car;
        }
        public void AddNew(Car car)
        {
            Car pro = GetCarById(car.CarID);
            if(pro == null)
            {
                CarList.Add(car);
            } else
            {
                throw new Exception("Car is already exists!");
            }
            
        }
        public void Update(Car car) { 
            Car c  = GetCarById(car.CarID);
            if(c != null)
            {
                var ind  = CarList.IndexOf(c);
                CarList[ind] = car;     
            } else
            {
                throw new Exception("Car does not already exists!");
            }
        }

        public void Remove(int CarID)
        {
            Car p = GetCarById(CarID); 
            if(p != null)
            {
                CarList.Remove(p);
            }
            else
            {
                throw new Exception("Car does not already exists!");
            }
        }
    }
}
