using ERP_Compressores.Application.DTOs;
using ERP_Compressores.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP_Compressores.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriaProdutosController : ControllerBase
{
    private readonly ICategoriaProdutoService _service;

    public CategoriaProdutosController(ICategoriaProdutoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategorias()
    {
        var categorias = await _service.GetAllCategoriasAsync();
        return Ok(categorias);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoriaById(int id)
    {
        var categoria = await _service.GetCategoriaByIdAsync(id);
        if (categoria == null)
            return NotFound();
        return Ok(categoria);
    }

    [HttpPost]
    public async Task<IActionResult> AddCategoria([FromBody] CategoriaProdutoDTO categoria)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var newCategoria = await _service.AddCategoriaAsync(categoria);
        return CreatedAtAction(nameof(GetCategoriaById), new { id = newCategoria.Id }, newCategoria);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategoria(int id, [FromBody] CategoriaProdutoDTO categoria)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        if (id != categoria.Id)
            return BadRequest("ID mismatch");
        var updatedCategoria = await _service.UpdateCategoriaAsync(categoria);
        return Ok(updatedCategoria);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategoria(int id)
    {
        var result = await _service.DeleteCategoriaAsync(id);
        if (!result)
            return NotFound();
        return NoContent();
    }

    [HttpPatch("deactivate/{id}")]
    public async Task<IActionResult> DeactivateCategoria(int id)
    {
        var updatedCategoria = await _service.DeactivateCategoria(id);
        return Ok(updatedCategoria);
    }

    [HttpPatch("activate/{id}")]
    public async Task<IActionResult> ActivateCategoria(int id)
    {
        var updatedCategoria = await _service.ActivateCategoria(id);
        return Ok(updatedCategoria);
    }

}
