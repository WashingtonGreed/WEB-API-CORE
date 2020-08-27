using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WEB_API_CORE.Data;
using WEB_API_CORE.Models;


[Route("lote")]
public class LoteController : ControllerBase
{

  [HttpGet]
  [Route("")]
  //[Authorize(Roles = "0")]
    public async Task<ActionResult<List<LOTE>>> Get([FromServices] DataContext context)
  { 
    var lotes = await context.LOTES.OrderByDescending(x => x.DATA).AsNoTracking().ToListAsync();
    return Ok(lotes);
  }

  [HttpGet]
  [Route("{id:int}")]
  public async Task<ActionResult<LOTE>> GetById(int id,[FromServices] DataContext context)
  {
    var lote = await context.LOTES.AsNoTracking().FirstOrDefaultAsync(x=> x.ID==id);
    return Ok(lote);
  }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult> Post([FromBody]List<LOTE> model, [FromServices] DataContext context)
    {
        try
        {
            IList<REMESSA> remessas;

            foreach (LOTE lote in model)
            {
                remessas = lote.REMESSA;
                lote.DATA = DateTime.Now;
                context.LOTES.Add(lote);
                context.REMESSAS.AddRange(remessas);
            }

            await context.SaveChangesAsync();
            return Ok(new
            {
                MENSAGEM = "LOTES CADASTRADOS COM SUCESSO"
            }

            );
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Não foi possivel criar um Lote" + ex });
        }

    }

    [HttpPut]
  [Route("{id:int}")]
  public async Task<ActionResult<List<LOTE>>> Put(int id, [FromBody]LOTE model,[FromServices] DataContext context)
  {

    if (id != model.ID)
      return NotFound(new { message = "Lote não encontrado" });

    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    try{

    context.Entry<LOTE>(model).State = EntityState.Modified;
    await context.SaveChangesAsync();
    return Ok(model);
    
    }catch(DbUpdateConcurrencyException)
    {
            return BadRequest(new { message = "Este registro já foi atualizado" });
    }catch
    {
            return BadRequest(new { message = "Não foi possivel atualizar o lote" });
    }

  }

  [HttpDelete]
  [Route("{id:int}")]
  public async Task<ActionResult<List<LOTE>>> Delete(int id,[FromServices] DataContext context)
  {
    var lote = await context.LOTES.FirstOrDefaultAsync(x => x.ID == id);
    if(lote == null){
      return NotFound(new { MENSAGEM = "Estoque não encontrada"});
    }

    try{
    context.LOTES.Remove(lote);
    await context.SaveChangesAsync();
    return Ok(new { MENSAGEM = "lote removido com sucesso" });
    
    }catch
    {
            return BadRequest(new { MENSAGEM = "Não foi possivel deletar o lote" });
    }
    
  }

}