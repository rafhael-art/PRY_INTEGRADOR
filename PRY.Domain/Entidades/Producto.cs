using System;
namespace PRY.Domain.Entidades
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Puntuacion { get; set; }
        public int IdRestaurante { get; set; }
    }
}

