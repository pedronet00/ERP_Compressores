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
        return Ok(novoCliente);
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
        try
        {
            var result = await _service.DeleteClienteAsync(id);

            return NoContent();
        } catch(Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        
        
    }

    [HttpPatch("deactivate/{id}")]
    [Authorize]
    public async Task<IActionResult> DeactivateCliente(int id)
    {
        try
        {
            var deactivatedCliente = await _service.DeactivateCliente(id);
            return Ok(deactivatedCliente);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
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
