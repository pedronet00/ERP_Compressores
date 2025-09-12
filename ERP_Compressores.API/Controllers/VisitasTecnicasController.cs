using ERP_Compressores.Application.DTOs;
using ERP_Compressores.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP_Compressores.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VisitasTecnicasController : ControllerBase
{
    private readonly IVisitasTecnicasService _service;

    public VisitasTecnicasController(IVisitasTecnicasService service)
    {
        _service = service;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllVisitasTecnicas()
    {
        var visitas = await _service.GetAllVisitasTecnicassAsync();
        return Ok(visitas);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetVisitaTecnicaById(int id)
    {
        var visita = await _service.GetVisitaTecnicaByIdAsync(id);
        if (visita == null)
            return NotFound();
        return Ok(visita);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddVisitaTecnica([FromBody] VisitasTecnicasDTO visita)
    {
        if (visita == null)
            return BadRequest("Dados da visita técnica não informados.");
        var novaVisita = await _service.AddVisitaTecnicaAsync(visita);
        return Ok(novaVisita);
    }

    [HttpPatch("{id}/cancelar")]
    [Authorize]
    public async Task<IActionResult> CancelarVisitaTecnica(int id)
    {
        var resultado = await _service.CancelarVisitaTecnica(id);
        if (resultado.Notifications.Any())
            return BadRequest(resultado.Notifications);
        return Ok(resultado.Result);
    }

    [HttpPatch("{id}/concluir")]
    [Authorize]
    public async Task<IActionResult> ConcluirVisitaTecnica(int id)
    {
        var resultado = await _service.ConcluirVisitaTecnica(id);
        if (resultado.Notifications.Any())
            return BadRequest(resultado.Notifications);
        return Ok(resultado.Result);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteVisitaTecnica(int id)
    {
        var resultado = await _service.DeleteVisitaTecnicaAsync(id);
        if (resultado.Notifications.Any())
            return BadRequest(resultado.Notifications);
        return Ok(resultado.Result);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateVisitaTecnica(int id, [FromBody] VisitasTecnicasDTO visita)
    {
        if (visita == null || id != visita.Id)
            return BadRequest("Dados da visita técnica inválidos.");
        var resultado = await _service.UpdateVisitaTecnicaAsync(visita);
        if (resultado.Notifications.Any())
            return BadRequest(resultado.Notifications);
        return Ok(resultado.Result);
    }

}
