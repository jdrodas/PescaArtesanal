﻿using PescaArtesanalAPI.Models;
using PescaArtesanalAPI.Services;
using Microsoft.AspNetCore.Mvc;


namespace PescaArtesanalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : Controller
    {
        private readonly DepartamentosService _departamentosService;

        public DepartamentosController(DepartamentosService departamentosService)
        {
            _departamentosService = departamentosService;
        }

        [HttpGet]
        public async Task<List<Departamento>> Get()
        {
            var losDepartamentos = await _departamentosService
                .GetAsync();
            
            return losDepartamentos;
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Departamento>> Get(string id)
        {
            var unDepartamento = await _departamentosService
                .GetAsync(id);

            if (unDepartamento is null)
                return NotFound();

            return unDepartamento;
        }
        [HttpGet("{id:length(24)}/Municipios")]
        public async Task<List<Municipio>> GetMunicipiosDelDepartamento(string id)
        {
            var unDepartamento = await _departamentosService
                .GetAsync(id);
            var losMunicipios = await _departamentosService
                .GetMunicipiosDelDepartamento(unDepartamento.Nombre!);

            return losMunicipios;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Departamento unDepartamento)
        {
            await _departamentosService
                .CreateAsync(unDepartamento);
            
            return CreatedAtAction(nameof(Get), new { id = unDepartamento.Id }, unDepartamento);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Departamento unDepartamento)
        {
            var departamentoExistente = await _departamentosService
                .GetAsync(id);

            if (departamentoExistente is null)
                return NotFound();

            await _departamentosService
                .UpdateAsync(id, unDepartamento);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Departamento unDepartamento)
        {
            var departamentoExistente = await _departamentosService
                .GetAsync(unDepartamento.Id!);

            if (departamentoExistente is null)
                return NotFound();

            await _departamentosService
                .UpdateAsync(unDepartamento.Id!, unDepartamento);
            
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var unDepartamento = await _departamentosService
                .GetAsync(id);
            
            if (unDepartamento is null)
                return NotFound();

            await _departamentosService.RemoveAsync(id);
            return NoContent();
        }
    }
}



