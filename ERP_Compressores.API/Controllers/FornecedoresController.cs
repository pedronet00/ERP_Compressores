using ERP_Compressores.Application.DTOs;
using ERP_Compressores.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP_Compressores.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FornecedoresController : ControllerBase
{
    private readonly IFornecedoresService _service;

    public FornecedoresController(IFornecedoresService service)
    {
        _service = service;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllFornecedores()
    {
        var fornecedores = await _service.GetAllFornecedoresAsync();
        return Ok(fornecedores);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetFornecedorById(int id)
    {
        var fornecedor = await _service.GetFornecedorByIdAsync(id);
        if (fornecedor == null)
            return NotFound();
        return Ok(fornecedor);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddFornecedor([FromBody] FornecedorDTO fornecedor)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var newFornecedor = await _service.AddFornecedorAsync(fornecedor);
        return CreatedAtAction(nameof(GetFornecedorById), new { id = newFornecedor.Id }, newFornecedor);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateFornecedor(int id, [FromBody] FornecedorDTO fornecedor)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        if (id != fornecedor.Id)
            return BadRequest("ID mismatch");
        var updatedFornecedor = await _service.UpdateFornecedorAsync(fornecedor);
        return Ok(updatedFornecedor);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteFornecedor(int id)
    {
        var result = await _service.DeleteFornecedorAsync(id);
        if (!result)
            return NotFound();
        return NoContent();
    }

    [HttpPatch("deactivate/{id}")]
    [Authorize]
    public async Task<IActionResult> DeactivateFornecedor(int id)
    {
        var fornecedor = await _service.DeactivateFornecedor(id);

        if (fornecedor == null)
            return NotFound();

        return Ok(fornecedor);
    }

    [HttpPatch("activate/{id}")]
    [Authorize]
    public async Task<IActionResult> ActivateFornecedor(int id)
    {
        var fornecedor = await _service.ActivateFornecedor(id);
        if (fornecedor == null)
            return NotFound();
        return Ok(fornecedor);
    }
}
