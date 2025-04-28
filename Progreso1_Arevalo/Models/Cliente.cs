using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Progreso1_ArevaloLenin.Models
{
    public class Cliente
    {
        [Key]
        [Display(Name = "")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El establecimiento no maneja valores mans de 500.")]
        [Range(0, 500)]
        public float ValorPagado { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; } = true;

        public List<Reserva> Reservas { get; set; }
        public virtual PlanRecompensa PlanRecompensa { get; set; }
    }
}
