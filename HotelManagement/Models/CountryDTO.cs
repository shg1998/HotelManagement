using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public class CountryDTO: CreateCountryDTO
    {
        public int Id { get; set; }
        public virtual IList<HotelDTO> Hotels { get; set; }
    }

    public class CreateCountryDTO
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Country Name is Too long !!")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 5, ErrorMessage = "Country ShortName is Too long !!")]
        public string ShortName { get; set; }
    }
}
