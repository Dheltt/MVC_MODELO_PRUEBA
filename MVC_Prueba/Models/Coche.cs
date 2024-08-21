namespace MVC_Prueba.Models
{
    public class Coche
    {


        public Coche(String IdCoche, String Marca, String Modelo, String Propietario)
        {
            this.IdCoche = IdCoche;
            this.Marca = Marca;
            this.Modelo = Modelo;
            this.Propietario = Propietario;
        }

        public string IdCoche { get; set; }
        public String Marca { get; set; }
        public String Modelo { get; set; }
        public String Propietario { get; set; }
    }
}
