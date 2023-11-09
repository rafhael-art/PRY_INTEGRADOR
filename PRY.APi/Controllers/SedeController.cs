using Microsoft.AspNetCore.Mvc;
using PRY.DataAcces.Interfaces;
using PRY.Domain.Entidades;

namespace PRY.APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SedeController : ControllerBase
    {
        private readonly ISedeService _service;

        public SedeController(ISedeService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var response = await _service.Listar();
            return Ok(response);
        }

        [HttpGet("{/id}")]
        public async Task<IActionResult> GeyById(int id)
        {

            var response = await _service.GetByID(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] Sede sede)
        {
            var response = await _service.Save(sede);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Sede sede)
        {

            var response = await _service.Edit(sede);
            return Ok(response);
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {

            var response = await _service.Delete(id);
            return Ok(response);
        }
    }
}

