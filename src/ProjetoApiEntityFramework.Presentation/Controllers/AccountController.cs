using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoApiEntittyFramework.Domain.Entities;
using ProjetoApiEntittyFramework.Infra.Contracts;
using ProjetoApiEntityFramework.Presentation.Models;

namespace ProjetoApiEntityFramework.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(AccountModel model, [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                #region Verificando se o email informado já está cadastrado

                if (usuarioRepository.Get(model.Email) != null)
                {
                    return StatusCode(403, "O email informado já encontra-se cadastrado. Tente outro.");
                }

                #endregion

                var usuario = new Usuario
                {
                    IdUsuario = Guid.NewGuid(),
                    Nome = model.Nome,
                    Email = model.Email,
                    Senha = model.Senha,
                    DataCriacao = DateTime.Now
                };

                usuarioRepository.Create(usuario);
                return Ok("Usuário cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                //retornando um status code de erro da API..
                return StatusCode(500, e.Message);
            }
        }
    }
}