using System.ComponentModel.DataAnnotations;

namespace Infrastruction.DomainObjects
{
    public class Car
    {
        public int CarId { get; set; }

        public string CarName { get; set; }

        //[UIHint("Enum")]
        public CarStatus Status { get; set; }
    }
}
