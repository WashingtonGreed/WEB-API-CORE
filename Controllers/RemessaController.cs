using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_API_CORE.Data;
using WEB_API_CORE.Models;

[Route("remessa")]
public class RemessaController : ControllerBase
{

    [HttpGet]
    [Route("")]
    //[Authorize(Roles = "0")]
    public async Task<ActionResult<List<REMESSA>>> Get([FromServices] DataContext context)
    {
        var remessa = await context.REMESSAS.AsNoTracking().ToListAsync();
        return Ok(
            new {  REMESSAS = remessa}
            ); 
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<REMESSA>> GetById(int id, [FromServices] DataContext context)
    {
        var remessa = await context.REMESSAS.AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);
        return Ok(remessa);
    }

    [HttpGet]
    [Route("lote/{id:int}")]
    public async Task<ActionResult<REMESSA>> GetByLoteId(int id, [FromServices] DataContext context)
    {
        var remessa = await context.REMESSAS.Where(x => x.LOTE.ID == id).ToListAsync();
        return Ok(remessa);
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<List<REMESSA>>> Post([FromBody]REMESSA model, [FromServices] DataContext context)
    {

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            context.REMESSAS.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
        }
        catch
        {
            return BadRequest(new { message = "Não foi possivel criar o remessa" });
        }

    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<List<REMESSA>>> Put(int id, [FromBody]REMESSA model, [FromServices] DataContext context)
    {

        if (id != model.ID)
            return NotFound(new { message = "remessa não encontrado" });

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {

            context.Entry<REMESSA>(model).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(model);

        }
        catch (DbUpdateConcurrencyException)
        {
            return BadRequest(new { message = "Este registro já foi atualizado" });
        }
        catch
        {
            return BadRequest(new { message = "Não foi possivel atualizar o remessa" });
        }

    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<List<REMESSA>>> Delete(int id, [FromServices] DataContext context)
    {
        var remessa = await context.REMESSAS.FirstOrDefaultAsync(x => x.ID == id);
        if (remessa == null)
        {
            return NotFound(new { message = "remessa não encontrada" });
        }

        try
        {
            context.REMESSAS.Remove(remessa);
            await context.SaveChangesAsync();
            return Ok(new { message = "remessa removida com sucesso" });

        }
        catch
        {
            return BadRequest(new { message = "Não foi possivel deletar a remessa" });

        }

    }

}