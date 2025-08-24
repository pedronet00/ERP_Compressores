using ERP_Compressores.Application.DTOs;
using ERP_Compressores.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP_Compressores.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _service;

    public ProdutoController(IProdutoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProdutos()
    {
        var produtos = await _service.GetAllProdutosAsync();
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProdutoById(int id)
    {
        var produto = await _service.GetProdutoByIdAsync(id);
        if (produto == null)
            return NotFound();
        return Ok(produto);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduto([FromBody] ProdutoDTO produto)
    {
        if (produto == null)
            return BadRequest("Produto é necessário.");
        var novoProduto = await _service.AddProdutoAsync(produto);
        return CreatedAtAction(nameof(GetProdutoById), new { id = novoProduto.Id }, novoProduto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduto(int id, [FromBody] ProdutoDTO produto)
    {
        if (produto == null || id != produto.Id)
            return BadRequest("Dados inválidos.");
        var updatedProduto = await _service.UpdateProdutoAsync(produto);
        return Ok(updatedProduto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduto(int id)
    {
        var result = await _service.DeleteProdutoAsync(id);
        if (!result)
            return NotFound();
        return NoContent();
    }
    [HttpPatch("deactivate/{id}")]
    public async Task<IActionResult> DeactivateProduto(int id)
    {
        var produto = await _service.DeactivateProduto(id);
        return Ok(produto);
    }

    [HttpPatch("activate/{id}")]
    public async Task<IActionResult> ActivateProduto(int id)
    {
        var produto = await _service.ActivateProduto(id);
        return Ok(produto);
    }
}
