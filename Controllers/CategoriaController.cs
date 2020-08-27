using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_API_CORE.Data;
using WEB_API_CORE.Models;

[Route("categoria")]
public class CategoriaController : ControllerBase
{

  [HttpGet]
  [Route("")]
  public async Task<ActionResult<List<CATEGORIA>>> Get([FromServices] DataContext context)
  { 
    var categorias = await context.CATEGORIAS.AsNoTracking().ToListAsync();
    return Ok(categorias);
  }

  [HttpGet]
  [Route("{id:int}")]
  public async Task<ActionResult<CATEGORIA>> GetById(int id,[FromServices] DataContext context)
  {
    var categoria = await context.CATEGORIAS.AsNoTracking().FirstOrDefaultAsync(x=> x.ID==id);
    return Ok(categoria);
  }

  [HttpPost]
  [Route("")]
  public async Task<ActionResult<List<CATEGORIA>>> Post([FromBody]CATEGORIA model, [FromServices] DataContext context)
  {

    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    try
    {
      context.CATEGORIAS.Add(model);
      await context.SaveChangesAsync();
      return Ok(model);
    }
    catch
    {
      return BadRequest(new { message = "Não foi possivel criar a Categoria" });
    }

  }

  [HttpPut]
  [Route("{id:int}")]
  public async Task<ActionResult<List<CATEGORIA>>> Put(int id, [FromBody]CATEGORIA model,[FromServices] DataContext context)
  {

    if (id != model.ID)
      return NotFound(new { message = "Categoria não encontrada" });

    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    try{

    context.Entry<CATEGORIA>(model).State = EntityState.Modified;
    await context.SaveChangesAsync();
    return Ok(model);
    
    }catch(DbUpdateConcurrencyException)
    {
            return BadRequest(new { message = "Este registro já foi atualizado" });

    }catch
    {
            return BadRequest(new { message = "Não foi possivel atualizar a Categoria" });

    }

  }

  [HttpDelete]
  [Route("{id:int}")]
  public async Task<ActionResult<List<CATEGORIA>>> Delete(int id,[FromServices] DataContext context)
  {
    var categoria = await context.CATEGORIAS.FirstOrDefaultAsync(x => x.ID == id);
    if(categoria==null){
      return NotFound(new { message = "Categoria não encontrada"});
    }

    try{

    context.CATEGORIAS.Remove(categoria);
    await context.SaveChangesAsync();
    return Ok(new { message = "Categoria removida com sucesso" });
    
    }catch
    {
            return BadRequest(new { message = "Não foi possivel deletar a Categoria" });

    }
    
  }

}