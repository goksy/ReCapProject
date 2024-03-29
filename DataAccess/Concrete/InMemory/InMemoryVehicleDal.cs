﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryVehicleDal : IVehicleDal
    {
        List<Car> _cars;
        public InMemoryVehicleDal()
        {
            _cars = new List<Car> {

            new Car{Id =1, BrandId=1, ColorId=14, DailyPrice=23, CarDescription = "Sedan", ModelYear = 2014},
            new Car{Id =2, BrandId=1, ColorId=13, DailyPrice=25, CarDescription = "Hatchback", ModelYear = 2015},
            new Car{Id =3, BrandId=2, ColorId=12, DailyPrice=23, CarDescription = "Sport", ModelYear = 2016},
            new Car{Id =4, BrandId=3, ColorId=10, DailyPrice=20, CarDescription = "SUV", ModelYear = 2020},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault (c=> c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByBrand(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.Id == carId).ToList();

        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.CarDescription = car.CarDescription;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
        
        }
    }
}
