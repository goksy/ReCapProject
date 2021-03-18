using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //ColorTest();

            VehicleManager vehicleManager = new VehicleManager(new EfCarDal());

            var result = vehicleManager.GetCarDetails();

            if (result.Success == true)
            {

                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + "/" + car.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorId = 33, ColorName = "Red" });
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Delete(new Brand { BrandId = 111, BrandName = "Black" });
            //brandManager.Update(new Brand { BrandId = 155, BrandName = "Black" });
            // brandManager.Add(new Brand { BrandId = 214, BrandName = "BMW" });
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName + brand.BrandId);
            }
        }







        private static void CarTest()
        {
            VehicleManager vehicleManager = new VehicleManager(new EfCarDal());
            vehicleManager.Add(new Car
            {
                Id = 10,
                BrandId = 333,
                ColorId = 33,
                ModelYear = 2017,
                DailyPrice = 15,
                CarDescription = "Sport Car",
                CarName = "Impreza"

            });
            //vehicleManager.Update(new Car { Id = 2, BrandId = 34, ColorId = 77, ModelYear = 2011, CarName = "Commodore", CarDescription = "V6", DailyPrice = 123 });


            //foreach (var car in vehicleManager.GetCarDetails())
            //{
            //    Console.WriteLine(car.ColorName + car.BrandName + car.ColorName + car.DailyPrice);
                    
            //}
        }
     
         
        
    }
}
