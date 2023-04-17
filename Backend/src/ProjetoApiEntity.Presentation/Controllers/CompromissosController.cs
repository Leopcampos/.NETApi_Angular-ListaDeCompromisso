using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoApiEntity.Domain.Entities;
using ProjetoApiEntity.Infra.Contracts;
using ProjetoApiEntity.Presentation.Models.Compromisso;

namespace ProjetoAPIEntity2.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompromissosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(CompromissoCadastroModel model,
            [FromServices] ICompromissoRepository compromissoRepository,
            [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                //buscar os dados do usuário autenticado na API..
                var usuario = usuarioRepository.Get(User.Identity.Name);

                //transferir os dados do model para a entidade Compromisso
                var compromisso = new Compromisso();

                compromisso.IdCompromisso = Guid.NewGuid();
                compromisso.Nome = model.Nome;
                compromisso.Data = DateTime.Parse(model.Data);
                compromisso.Hora = TimeSpan.Parse(model.Hora);
                compromisso.Descricao = model.Descricao;
                compromisso.IdUsuario = usuario.IdUsuario;

                compromissoRepository.Create(compromisso);

                return Ok("Compromisso cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                //retornar status de erro 500 (Internal Server Error)
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(CompromissoEdicaoModel model,
            [FromServices] ICompromissoRepository compromissoRepository,
            [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                //obter o usuario autenticado..
                var usuario = usuarioRepository.Get(User.Identity.Name);

                //obter o compromisso no banco de dados
                var compromisso = compromissoRepository.GetById(model.IdCompromisso);

                //verificar se o compromisso foi encontrado e se pertence ao usuario autenticado..
                if (compromisso != null && compromisso.IdUsuario == usuario.IdUsuario)
                {
                    compromisso.Nome = model.Nome;
                    compromisso.Data = DateTime.Parse(model.Data);
                    compromisso.Hora = TimeSpan.Parse(model.Hora);
                    compromisso.Descricao = model.Descricao;

                    compromissoRepository.Update(compromisso);

                    return Ok("Compromisso atualizado com sucesso.");
                }
                else
                {
                    return StatusCode(403, "Compromisso inválido para edição.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id,
            [FromServices] ICompromissoRepository compromissoRepository,
            [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                //obter o usuario autenticado..
                var usuario = usuarioRepository.Get(User.Identity.Name);

                //obter o compromisso atraves do id..
                var compromisso = compromissoRepository.GetById(id);

                //verificar se o compromisso existe e se pertence ao usuario autenticado
                if (compromisso != null && compromisso.IdUsuario == usuario.IdUsuario)
                {
                    //excluindo o compromisso
                    compromissoRepository.Delete(compromisso);

                    return Ok("Compromisso excluido com sucesso.");
                }
                else
                {
                    return StatusCode(403, "Compromisso inválido para exclusão.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [ProducesResponseType(typeof(List<CompromissoConsultaModel>), 200)]
        [HttpGet("{dataInicio}/{dataFim}")]
        public IActionResult GetAll(DateTime dataInicio, DateTime dataFim,
            [FromServices] ICompromissoRepository compromissoRepository,
            [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                //obter o usuario autenticado..
                var usuario = usuarioRepository.Get(User.Identity.Name);

                //consultar os compromissos..
                var compromissos = compromissoRepository.GetByDatas(dataInicio, dataFim, usuario.IdUsuario);

                //retornar os dados obtidos
                var result = new List<CompromissoConsultaModel>();

                foreach (var item in compromissos)
                {
                    result.Add(new CompromissoConsultaModel
                    {
                        IdCompromisso = item.IdCompromisso,
                        Nome = item.Nome,
                        Data = item.Data.ToString("dd/MM/yyyy"),
                        Hora = item.Hora.ToString(),
                        Descricao = item.Descricao
                    });
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [ProducesResponseType(typeof(CompromissoConsultaModel), 200)]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id,
            [FromServices] ICompromissoRepository compromissoRepository,
            [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                //obter o usuario autenticado
                var usuario = usuarioRepository.Get(User.Identity.Name);

                //obter o compromisso pelo id..
                var compromisso = compromissoRepository.GetById(id);

                //verificando se o compromisso foi encontrado e se pretence ao usuario autenticado..
                if (compromisso != null && compromisso.IdUsuario == usuario.IdUsuario)
                {
                    var result = new CompromissoConsultaModel
                    {
                        IdCompromisso = compromisso.IdCompromisso,
                        Nome = compromisso.Nome,
                        Data = compromisso.Data.ToString("dd/MM/yyyy"),
                        Hora = compromisso.Hora.ToString(),
                        Descricao = compromisso.Descricao
                    };

                    return Ok(result);
                }
                else
                {
                    return StatusCode(403, "Compromisso inválido ou não encontrado.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}