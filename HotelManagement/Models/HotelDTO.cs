using System;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public class HotelDTO : CreateHotelDTO
    {
        public int Id { get; set; }
        public CountryDTO Country { get; set; }
    }

    public class CreateHotelDTO
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

}
