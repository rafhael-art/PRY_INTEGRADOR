using System;
using PRY.DataAcces.Interfaces;

namespace PRY.Logic
{
    public class UsuarioImple
    {
        private readonly IUsuarioService _service;
        public UsuarioImple(IUsuarioService service)
        {
            _service = service;
        }


    }
}

