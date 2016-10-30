using System;
using System.Collections.Generic;
using Infrastruction.DomainObjects;

namespace Infrastruction
{
    public interface ICarService
    {
        Car GetCar(int id);

        IEnumerable<Car> GetAllCars(Func<Car, bool> selector);
    }
}