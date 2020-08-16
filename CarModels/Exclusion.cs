using System.ComponentModel.DataAnnotations;

namespace car_webapi.db.models
{
    public class Exclusion
    {
        public int Id { get; set; }

        [Required]
        public int Sonderausstattung { get; set; }

        [Required]
        public int Cannot { get; set; }
    }
}