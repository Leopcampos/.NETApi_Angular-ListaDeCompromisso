using Microsoft.AspNetCore.Mvc;
using ProjetoApiEntity.CrossCutting.Cryptography;
using ProjetoApiEntity.Domain.Entities;
using ProjetoApiEntity.Infra.Contracts;
using ProjetoApiEntity.Presentation.Models;

namespace ProjetoApiEntity.Presentation.Controllers
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
                    return StatusCode(403, new {Message = "O email informado já encontra-se cadastrado. Tente outro."});
                }

                #endregion

                var usuario = new Usuario
                {
                    IdUsuario = Guid.NewGuid(),
                    Nome = model.Nome,
                    Email = model.Email,
                    Senha = MD5Cryptography.Encrypt(model.Senha),
                    DataCriacao = DateTime.Now
                };

                usuarioRepository.Create(usuario);
                return Ok(new
                {
                    Message = "Usuário cadastrado com sucesso."
                });
            }
            catch (Exception e)
            {
                //retornando um status code de erro da API..
                return StatusCode(500, e.Message);
            }
        }
    }
}