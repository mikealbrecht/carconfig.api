using System.ComponentModel.DataAnnotations;

namespace car_webapi.db.models
{
    public class Sonderausstattung
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Value { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}