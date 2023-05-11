using PescaArtesanalAPI.Models;
using PescaArtesanalAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace PescaArtesanalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuencasController : Controller
    {
        private readonly CuencasService _cuencasService;

        public CuencasController(CuencasService cuencasService)
        {
            _cuencasService = cuencasService;
        }

        [HttpGet]
        public async Task<List<Cuenca>> Get()
        {
            var lasCuencas = await _cuencasService
                .GetAsync();
            
            return lasCuencas;
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Cuenca>> Get(string id)
        {
            var unaCuenca = await _cuencasService
                .GetAsync(id);

            if (unaCuenca is null)
                return NotFound();

            return unaCuenca;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cuenca unaCuenca)
        {
            await _cuencasService
                .CreateAsync(unaCuenca);
            
            return CreatedAtAction(nameof(Get), new { id = unaCuenca.Id }, unaCuenca);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Cuenca unaCuenca)
        {
            var cuencaExistente = await _cuencasService
                .GetAsync(id);

            if (cuencaExistente is null)
                return NotFound();

            await _cuencasService
                .UpdateAsync(id, unaCuenca);
            
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Cuenca unaCuenca)
        {
            var cuencaExistente = await _cuencasService
                .GetAsync(unaCuenca.Id!);

            if (cuencaExistente is null)
                return NotFound();

            await _cuencasService
                .UpdateAsync(unaCuenca.Id!, unaCuenca);
            
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var unaCuenca = await _cuencasService
                .GetAsync(id);

            if (unaCuenca is null)
                return NotFound();

            await _cuencasService
                .RemoveAsync(id);
            
            return NoContent();
        }
    }
}

