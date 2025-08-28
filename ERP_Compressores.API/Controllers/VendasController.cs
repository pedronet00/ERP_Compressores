using ERP_Compressores.Application.DTOs;
using ERP_Compressores.Application.Interfaces;
using ERP_Compressores.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP_Compressores.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VendasController : ControllerBase
{
    private readonly IVendasService _vendasService;

    public VendasController(IVendasService vendasService) => _vendasService = vendasService;

    [HttpPost]
    public async Task<IActionResult> RegistrarVenda([FromBody] RegistrarVendaDTO dto)
    {
        var vendaCriada = await _vendasService.RegistrarVendaAsync(dto);
        return Ok(vendaCriada);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterVenda(int id)
    {
        var venda = await _vendasService.ObterVendaAsync(id);
        if (venda == null) return NotFound();
        return Ok(venda);
    }

    [HttpGet]
    public async Task<IActionResult> ListarVendas() =>
        Ok(await _vendasService.ListarVendasAsync());

    [HttpGet("count")]
    public async Task<IActionResult> CountVendas()
    {
        var vendas = await _vendasService.CountVendas();
        return Ok(vendas);
    }
}
