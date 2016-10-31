using System.ComponentModel.DataAnnotations;

namespace Infrastruction.DomainObjects
{
    public class Car
    {
        //[System.ComponentModel.DataAnnotations.Display(=false)]
        public int CarId { get; set; }

        [Display(Name="Name of car")]
        public string CarName { get; set; }

        [Display(Name="Total count of car")]
        [Range(0, 1000)]
        public int TotalCount { get; set; }

        [System.ComponentModel.DataAnnotations.EnumDataType(typeof(CarStatus))]
        public CarStatus Status { get; set; }
    }
}
