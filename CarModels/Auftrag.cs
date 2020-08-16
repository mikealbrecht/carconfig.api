using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace car_webapi.db.models
{
    public class Auftrag
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(36)]
        [Column(TypeName = "varchar(36)")]
        public string Guid { get; set; }

        [Required]
        public int Motor { get; set; }

        [Required]
        public int Lackierung { get; set; }

        [Required]
        public int Felgen { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }
    }
}