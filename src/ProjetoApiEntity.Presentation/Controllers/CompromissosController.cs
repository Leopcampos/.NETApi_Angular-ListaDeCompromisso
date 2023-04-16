using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoApiEntity.Presentation.Models.Compromisso;

namespace ProjetoApiEntity.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompromissosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(CompromissoCadastroModel model)
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(CompromissoEdicaoModel model)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok();
        }

        [ProducesResponseType(typeof(List<CompromissoConsultaModel>), 200)]
        [HttpGet]
        public IActionResult GetAll(DateTime dataInicio, DateTime dataFim)
        {
            return Ok();
        }

        [ProducesResponseType(typeof(CompromissoConsultaModel), 200)]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok();
        }
    }
}