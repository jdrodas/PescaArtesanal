using PescaArtesanalAPI.Models;
using PescaArtesanalAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace PescaArtesanalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadesController : Controller
    {
        private readonly ActividadesService _actividadesService;

        public ActividadesController(ActividadesService actividadesService)
        {
            _actividadesService = actividadesService;
        }

        [HttpGet]
        public async Task<List<Actividad>> Get()
        {
            var lasActividades = await _actividadesService
                .GetAsync();

            return lasActividades;
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Actividad>> Get(string id)
        {
            var unaActividad = await _actividadesService
                .GetAsync(id);

            if (unaActividad is null)
                return NotFound();

            return unaActividad;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Actividad unaActividad)
        {
            await _actividadesService
                .CreateAsync(unaActividad);

            return CreatedAtAction(nameof(Get), new { id = unaActividad.Id }, unaActividad);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Actividad unaActividad)
        {
            var actividadExistente = await _actividadesService
                .GetAsync(id);

            if (actividadExistente is null)
                return NotFound();

            await _actividadesService
                .UpdateAsync(id, unaActividad);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Actividad unaActividad)
        {
            var actividadExistente = await _actividadesService
                .GetAsync(unaActividad.Id!);

            if (actividadExistente is null)
                return NotFound();

            await _actividadesService
                .UpdateAsync(unaActividad.Id!, unaActividad);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var unaActividad = await _actividadesService
                .GetAsync(id);

            if (unaActividad is null)
                return NotFound();

            await _actividadesService
                .RemoveAsync(id);

            return NoContent();
        }
    }
}

