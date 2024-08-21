namespace MVC_Prueba.Models
{
    public class Garaje : List<Coche>
    {
        public Garaje()
        {
            this.Add(new Coche("1", "tesla", "Roadster", "Elon Musk"));
            this.Add(new Coche("2", "Toyota", "Yaris", "Jhoseph Joestar"));
            this.Add(new Coche("3", "Honda", "Civic", "M. Rajoy"));
            this.Add(new Coche("4", "Ferrari", "F40", "Bill Gates"));
            this.Add(new Coche("5", "Nissan", "skiper", "Goku"));
        }


    }
}
