using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace _1CasoPractico_OscarNaranjoZuniga.Models
{
    public class Servicio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Nombre { get; set; }

        [MaxLength(500)]
        public required string Descripcion { get; set; }

        [Required]
        [Precision(18, 2)]
        public decimal Costo { get; set; }

        [Required]
        public int Duracion { get; set; }  // en minutos

        [Required]
        public bool Estado { get; set; }

        [MaxLength(200)]
        public required string Ubicacion { get; set; }

        public string? Imagen { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime FechaCreacion { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? FechaModificacion { get; set; }
    }
}
