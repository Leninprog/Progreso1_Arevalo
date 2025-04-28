namespace Progreso1_ArevaloLenin.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string InformacionCliente { get; set; }
        public float ValorPagado { get; set; }

    }
}
