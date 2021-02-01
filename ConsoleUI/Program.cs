using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            VehicleManager vehicleManager = new VehicleManager(new InMemoryVehicleDal());
            foreach (var item in vehicleManager.GetAll())
            {
                Console.WriteLine(item.Description);
            }

        }
    }
}
