using ERP_Compressores.Application.DTOs;
using ERP_Compressores.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP_Compressores.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly IClientesService _service;

    public ClientesController(IClientesService service)
    {
        _service = service;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllClientes()
    {
        var clientes = await _service.GetAllClientesAsync();
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetClienteById(int id)
    {
        var cliente = await _service.GetClienteByIdAsync(id);
        if (cliente == null)
            return NotFound();
        return Ok(cliente);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddCliente([FromBody] ClienteDTO cliente)
    {
        if (cliente == null)
            return BadRequest("Dados do cliente não informados.");
        var novoCliente = await _service.AddClienteAsync(cliente);
        return CreatedAtAction(nameof(GetClienteById), new { id = novoCliente.Id }, novoCliente);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateCliente(int id, [FromBody] ClienteDTO cliente)
    {
        if (cliente == null || id != cliente.Id)
            return BadRequest("Dados do cliente inválidos.");
        var updatedCliente = await _service.UpdateClienteAsync(cliente);
        return Ok(updatedCliente);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteCliente(int id)
    {
        var result = await _service.DeleteClienteAsync(id);
        if (!result)
            return NotFound();
        return NoContent();
    }

    [HttpPatch("deactivate/{id}")]
    [Authorize]
    public async Task<IActionResult> DeactivateCliente(int id)
    {
        var deactivatedCliente = await _service.DeactivateCliente(id);
        return Ok(deactivatedCliente);
    }

    [HttpPatch("activate/{id}")]
    [Authorize]
    public async Task<IActionResult> ActivateCliente(int id)
    {
        var activatedCliente = await _service.ActivateCliente(id);
        return Ok(activatedCliente);
    }

    [HttpGet("count")]
    [Authorize]
    public async Task<IActionResult> CountClientes()
    {
        var count = await _service.CountClientes();
        return Ok(count);
    }

}
