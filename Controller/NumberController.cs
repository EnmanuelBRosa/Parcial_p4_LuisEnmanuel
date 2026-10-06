using Microsoft.AspNetCore.Mvc;
using Parcial_p4_LuisEnmanuel.Models;
using Parcial_p4_LuisEnmanuel.Servicios;

namespace Parcial_p4_LuisEnmanuel.Controller;

[Route("api/[controller]")]
[ApiController]
public class NumberController (NumbersService service) : ControllerBase
{
    [HttpGet("numero/{numero:int}")]

    public async Task<IActionResult> Numero(int numero)
    {
        int resultado = numero + numero;
        
        var record = new NumberRecord(
        0,
        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
        numero,
        resultado);

        await service.SaveAsync(record);

        return Ok(resultado);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<NumberRecord>> GetById(int id)
    {
        var record = await service.GetByIdAsync(id);

        if (record == null)
            return NotFound();

        return Ok(record);
    }

    [HttpGet("historial")]
    public async Task<ActionResult<IEnumerable<NumberRecord>>> GetList()
    {
        var records = await service.GetListAsync();
        return Ok(records);
    }
}

