using System;
using System.ComponentModel.DataAnnotations;
using SmartMed.Models.Models.Validations;

namespace SmartMed.Models.Models
{
    public class Medication
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [GreaterThanZero]
        public double Quantity { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}
