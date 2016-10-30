using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastruction;
using Infrastruction.DomainObjects;

namespace FakeServiceLayer
{
    public class FakeCarService : ICarService
    {
        public Infrastruction.DomainObjects.Car GetCar(int id)
        {
            return new Car();
        }

        public IEnumerable<Infrastruction.DomainObjects.Car> GetAllCars(Func<Infrastruction.DomainObjects.Car, bool> selector)
        {
            return Enumerable.Empty<Car>();
        }
    }
}
