using PescaArtesanalAPI.Models;
using PescaArtesanalAPI.Services;
using Microsoft.AspNetCore.Mvc;


namespace PescaArtesanalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipiosController : Controller
    {
        private readonly MunicipiosService _municipiosService;

        public MunicipiosController(MunicipiosService departamentosService)
        {
            _municipiosService = departamentosService;
        }

        [HttpGet]
        public async Task<List<Municipio>> Get()
        {
            var losMunicipios = await _municipiosService.GetAsync();
            return losMunicipios;
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Municipio>> Get(string id)
        {
            var unMunicipio = await _municipiosService.GetAsync(id);

            if (unMunicipio is null)
                return NotFound();

            return unMunicipio;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Municipio unMunicipio)
        {
            await _municipiosService.CreateAsync(unMunicipio);
            return CreatedAtAction(nameof(Get), new { id = unMunicipio.Id }, unMunicipio);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Municipio unMunicipio)
        {
            var municipioExistente = await _municipiosService.GetAsync(id);

            if (municipioExistente is null)
                return NotFound();

            unMunicipio.Id = municipioExistente.Id;
            await _municipiosService.UpdateAsync(id, unMunicipio);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var unMunicipio = await _municipiosService.GetAsync(id);
            
            if (unMunicipio is null)
                return NotFound();

            await _municipiosService.RemoveAsync(id);
            return NoContent();
        }
    }
}



