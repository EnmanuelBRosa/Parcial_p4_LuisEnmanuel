using Microsoft.AspNetCore.Mvc;
using Parcial_p4_LuisEnmanuel.Modelos;
using Parcial_p4_LuisEnmanuel.Servicios;

namespace Parcial_p4_LuisEnmanuel.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberController : ControllerBase
    {
        private readonly NumbersService _numbersService;

        public NumberController(NumbersService numbersService)
        {
            _numbersService = numbersService;
        }

        [HttpGet("numero/{numero:int}")]
        public async Task<IActionResult> Numero(int numero)
        {
            int resultado = numero + numero;

            var record = new NumberRecord
            {
                Fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Numero = numero,
                Resultado = resultado
            };

            await _numbersService.SaveAsync(record);

            return Ok(resultado);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<NumberRecord>> GetById(int id)
        {
            var record = await _numbersService.GetByIdAsync(id);

            if (record == null)
                return NotFound();

            return Ok(record);
        }

        [HttpGet("historial")]
        public async Task<ActionResult<IEnumerable<NumberRecord>>> GetList()
        {
            var records = await _numbersService.GetListAsync();
            return Ok(records);
        }
    }
}
