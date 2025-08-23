using ERP_Compressores.Application.DTOs;
using ERP_Compressores.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP_Compressores.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {

        private readonly IEmpresasService _service;

        public EmpresasController(IEmpresasService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAEmpresasAsync()
        {
            var empresas = await _service.GetAllEmpresasAsync();

            return Ok(empresas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpresaByIdAsync(int id)
        {
            var empresa = await _service.GetEmpresaByIdAsync(id);
            
            if (empresa == null)
                return NotFound();
            
            return Ok(empresa);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmpresaAsync([FromBody] EmpresaDTO empresa)
        {
            if (empresa == null)
                return BadRequest("Empresa não pode ser nula.");
            
            var createdEmpresa = await _service.AddEmpresaAsync(empresa);

            return Ok(createdEmpresa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmpresaAsync(int id, [FromBody] EmpresaDTO empresa)
        {
            if (empresa == null || id != empresa.Id)
                return BadRequest("Dados inválidos.");

            var updatedEmpresa = await _service.UpdateEmpresaAsync(empresa);

            if (updatedEmpresa == null)
                return NotFound();
            
            return Ok(updatedEmpresa);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresaAsync(int id)
        {
            var result = await _service.DeleteEmpresaAsync(id);
            if (!result)
                return NotFound();
            
            return NoContent();
        }

        [HttpPatch("deactivate/{id}")]
        public async Task<IActionResult> DeactivateEmpresa(int id)
        {
            try
            {
                var updatedEmpresa = await _service.DeactivateEmpresa(id);

                return Ok(updatedEmpresa);
            }
            catch (KeyNotFoundException ex)
            {

                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("activate/{id}")]
        public async Task<IActionResult> ActivateEmpresa(int id)
        {
            try
            {
                var updatedEmpresa = await _service.ActivateEmpresa(id);


                return Ok(updatedEmpresa);
            }
            catch (KeyNotFoundException ex)
            {

                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
