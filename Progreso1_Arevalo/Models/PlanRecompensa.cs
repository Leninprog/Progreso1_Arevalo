namespace Progreso1_ArevaloLenin.Models
{
    public class PlanRecompensa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public int PuntosAcumulados { get; set; }
        public bool TipoRecompensa { get; set; } = true;
    }
}
