using ERP_Compressores.Application.DTOs;
using ERP_Compressores.Application.Interfaces;
using ERP_Compressores.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP_Compressores.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{

    private readonly IUsuarioService _service;

    public UsuarioController(IUsuarioService service)
    {
        _service = service;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllUsuarios()
    {
        var usuarios = await _service.GetAllUsuariosAsync();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetUsuarioById(int id)
    {
        var usuario = await _service.GetUsuarioByIdAsync(id);
        if (usuario == null)
            return NotFound();
        return Ok(usuario);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateFornecedor(int id, [FromBody] UsuarioDTO usuario)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        if (id != usuario.Id)
            return BadRequest("ID mismatch");
        var updatedUsuario = await _service.UpdateUsuarioAsync(usuario);
        return Ok(updatedUsuario);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteUsuario(int id)
    {
        var result = await _service.DeleteUsuarioAsync(id);
        if (!result)
            return NotFound();
        return NoContent();
    }

    [HttpPatch("deactivate/{id}")]
    [Authorize]
    public async Task<IActionResult> DeactivateUsuario(int id)
    {
        var usuario = await _service.DeactivateUsuario(id);

        if (usuario == null)
            return NotFound();

        return Ok(usuario);
    }

    [HttpPatch("activate/{id}")]
    [Authorize]
    public async Task<IActionResult> ActivateUsuario(int id)
    {
        var usuario = await _service.ActivateUsuario(id);
        if (usuario == null)
            return NotFound();
        return Ok(usuario);
    }
}
