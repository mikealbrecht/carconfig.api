using System.ComponentModel.DataAnnotations;

namespace car_webapi.db.models
{
    public class Ausstattung
    {
        public int Id { get; set; }

        [Required]
        public int Auftrag { get; set; }

        [Required]
        public int Sonderausstattung { get; set; }
    }
}