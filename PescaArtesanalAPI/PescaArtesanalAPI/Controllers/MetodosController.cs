using PescaArtesanalAPI.Models;
using PescaArtesanalAPI.Services;
using Microsoft.AspNetCore.Mvc;


namespace PescaArtesanalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetodosController : Controller
    {
        private readonly MetodosService _metodosService;

        public MetodosController(MetodosService departamentosService)
        {
            _metodosService = departamentosService;
        }

        [HttpGet]
        public async Task<List<Metodo>> Get()
        {
            var losMetodos = await _metodosService.GetAsync();
            return losMetodos;
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Metodo>> Get(string id)
        {
            var unMetodo = await _metodosService.GetAsync(id);

            if (unMetodo is null)
                return NotFound();

            return unMetodo;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Metodo unMetodo)
        {
            await _metodosService.CreateAsync(unMetodo);
            return CreatedAtAction(nameof(Get), new { id = unMetodo.Id }, unMetodo);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Metodo unMetodo)
        {
            var departamentoExistente = await _metodosService.GetAsync(id);

            if (departamentoExistente is null)
                return NotFound();

            unMetodo.Id = departamentoExistente.Id;
            await _metodosService.UpdateAsync(id, unMetodo);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var unMetodo = await _metodosService.GetAsync(id);
            
            if (unMetodo is null)
                return NotFound();

            await _metodosService.RemoveAsync(id);
            return NoContent();
        }
    }
}



