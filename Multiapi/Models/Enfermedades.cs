namespace Clase.Models{
   public class Enfermedades{
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Peligrosidad { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaDescubrimiento { get; set;}
    }
}