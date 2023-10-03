using AutomobileSolution.BusinessObject;
using AutomobileSolution.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace AutomobileSolution.Repository
{
    internal class CarRepository : ICarRepository
    {
        public void DeleteCar(int carId) => CarDBContext.Instance.Remove(carId);

        public Car GetCarByID(int carId) => CarDBContext.Instance.GetCarById(carId);

        public IEnumerable<Car> GetCars() => CarDBContext.Instance.GetCarList;

        public void InsertCar(Car car) => CarDBContext.Instance.AddNew(car);

        public void UpdateCar(Car car) => CarDBContext.Instance.Update(car);
    }
}
