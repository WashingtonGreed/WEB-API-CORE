using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_API_CORE.Data;
using WEB_API_CORE.Models;
using WEB_API_CORE.Services;

[Route("usuario")]
public class UsuarioController : ControllerBase
{


    [HttpGet]
    [Route("")]
    [Authorize(Roles = "0")]
    public async Task<ActionResult<List<USUARIO>>> Get([FromServices] DataContext context)
    {

        var usuarios = await context
        .USUARIOS
        .AsNoTracking()
        .ToListAsync();

        return usuarios;

    }


    [HttpPost]
    [Route("")]
    public async Task<ActionResult<USUARIO>> Post([FromBody]USUARIO model, [FromServices] DataContext context)
    {

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        USUARIO usuario = await context.USUARIOS
        .AsNoTracking()
        .Where(x => x.EMAIL == model.EMAIL)
        .FirstOrDefaultAsync();

        if (usuario != null)
            return BadRequest(new { mensagem = "Este e-mail já esta em uso" });

         usuario = await context.USUARIOS
        .AsNoTracking()
        .Where(x => x.CPF_CNPJ == model.CPF_CNPJ)
        .FirstOrDefaultAsync();

        if (usuario != null)
            return BadRequest(new { mensagem = "Este CPF/CNPJ já esta em uso" });

        try
        {
            model.ACESSO = "0";
            context.USUARIOS.Add(model);
            await context.SaveChangesAsync();
            return Ok( new
            { USUARIO = usuario,
              mensagem = "Usuario cadastrado com sucesso!"
            }

            );
        }
        catch
        {
            return BadRequest(new { message = "Não foi possivel criar um Usuario" });
        }

    }

    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> Autenticacao([FromServices] DataContext context, [FromBody]USUARIO model)
    {
        USUARIO usuario = await context.USUARIOS
        .AsNoTracking()
        .Where(x => x.EMAIL == model.EMAIL && x.SENHA == model.SENHA)
        .FirstOrDefaultAsync();

        if (usuario == null)
            return NotFound(new { message = "Usuario ou senha invalidos" });


        var token = TokenService.GenerateToken(usuario);

        usuario.SENHA = "";

        return new
        {
            USUARIO = usuario,
            TOKEN = token

        };


    }


}