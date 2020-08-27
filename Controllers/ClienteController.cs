using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_API_CORE.Data;
using WEB_API_CORE.Models;
using WEB_API_CORE.Services;

[Route("cliente")]
public class ClienteController : ControllerBase
{


    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<CLIENTE>>> Get([FromServices] DataContext context)
    {
        var clientes = await context
        .CLIENTES
        .AsNoTracking()
        .ToListAsync();

        return clientes;

    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<CLIENTE>> Post([FromBody] CLIENTE model, [FromServices] DataContext context)
    {

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        CLIENTE cliente = await context.CLIENTES
        .AsNoTracking()
        .Where(x => x.EMAIL == model.EMAIL)
        .FirstOrDefaultAsync();

        if (cliente != null)
            return BadRequest(new { mensagem = "Este e-mail já esta em uso" });

        cliente = await context.CLIENTES
       .AsNoTracking()
       .Where(x => x.CPF_CNPJ == model.CPF_CNPJ)
       .FirstOrDefaultAsync();

        if (cliente != null)
            return BadRequest(new { mensagem = "Este CPF/CNPJ já esta em uso" });

        try
        {
            context.CLIENTES.Add(model);
            await context.SaveChangesAsync();
            return Ok(new
            {
                CLIENTE = cliente,
                mensagem = "Usuario cadastrado com sucesso!"
            }

            );
        }
        catch
        {
            return BadRequest(new { message = "Não foi possivel criar o cliente" });
        }

    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<CLIENTE>> Put(int id, [FromBody] PRODUTO model, [FromServices] DataContext context)
    {

        if (id != model.ID)
            return NotFound(new { message = "Cliente não encontrada" });

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {

            context.Entry<PRODUTO>(model).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(model);

        }
        catch (DbUpdateConcurrencyException)
        {
            return BadRequest(new { message = "Este cliente já foi atualizado" });

        }
        catch
        {
            return BadRequest(new { message = "Não foi possivel atualizar a cliente" });

        }

    }

}