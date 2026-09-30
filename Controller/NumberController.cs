using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
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
        public IActionResult Numero(int numero)
        {

            return Ok(numero + numero);
        }

    }

 }   

