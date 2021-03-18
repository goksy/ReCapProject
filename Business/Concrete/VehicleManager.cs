using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class VehicleManager : IVehicleService
    {
        IVehicleDal _vehicleDal;

        
        public VehicleManager(IVehicleDal vehicleDal)
        {
            _vehicleDal = vehicleDal;
        }

        public IResult Add(Car car)
        {
            if(car.DailyPrice < 0 && car.CarName.Length < 3)
            {

                return new ErrorResult(Messages.VehicleNameInvalid);
                
            } 

            _vehicleDal.Add(car);

            return new SuccessResult(Messages.VehicleAdded);
        }

        public IResult Delete(Car car)
        {
           _vehicleDal.Delete(car);
            return new SuccessResult(Messages.VehicleDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if(DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_vehicleDal.GetAll(), Messages.VehicleListed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_vehicleDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_vehicleDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>( _vehicleDal.Get(c => c.Id == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            //if (DateTime.Now.Hour == 3)
            //{
            //    return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<CarDetailDto>>(_vehicleDal.GetCarDetails());
        }

        public IResult Update(Car car)
        {
            _vehicleDal.Update(car);
            return new SuccessResult();
        }
    }
}
