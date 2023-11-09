using System;
namespace PRY.Domain.Entidades
{
    public class Mesa
    {
        public int Id { get; set; }
        public int IdRestaurante { get; set; }
        public int NumeroMesa { get; set; }
        public int Capacidad { get; set; }
        public int IdSede { get; set; }
    }
}

