using System.ComponentModel.DataAnnotations;

namespace Progreso1_ArevaloLenin.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Range(0, 500)]
        public float ValorPagado { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }

        public bool Estado { get; set; } = true;

        [Required]
        public int PlanRecompensaId { get; set; } 
        public virtual PlanRecompensa PlanRecompensa { get; set; }

        public List<Reserva> Reservas { get; set; }
    }
}
