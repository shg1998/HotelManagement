using System;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public class HotelDto : CreateHotelDto
    {
        public int Id { get; set; }
        public CountryDto Country { get; set; }
    }

    public class CreateHotelDto
    {
        [Required]
        [StringLength(maximumLength: 200, ErrorMessage = "Hotel Name is Too long !!")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 400, ErrorMessage = "Hotel Address is Too long !!")]
        public string Address { get; set; }

        [Required]
        [Range(1, 5)]
        public double Rating { get; set; }

        [Required]
        public int CountryId { get; set; }

    }

    public class UpdateHotelDto : CreateHotelDto
    {

    }
}
