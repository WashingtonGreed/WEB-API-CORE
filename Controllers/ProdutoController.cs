using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_API_CORE.Data;
using WEB_API_CORE.Models;

[Route("produtos")]
public class ProdutoController : ControllerBase
{

  [HttpGet]
  [Route("")]
  [Authorize(Roles="0")]
  public async Task<ActionResult<List<PRODUTO>>> Get([FromServices] DataContext context)
  {
    var produtos = await context
    .PRODUTOS
    .Include(x => x.CATEGORIA)
    .AsNoTracking()
    .ToListAsync();
    return Ok(produtos);
  }

  [HttpGet]
  [Route("{id:int}")]
  [Authorize(Roles="0")]
  public async Task<ActionResult<PRODUTO>> GetById(int id, [FromServices] DataContext context)
  {
    var produtos = await context
    .PRODUTOS
    .Include(x => x.CATEGORIA)
    .AsNoTracking()
    .FirstOrDefaultAsync(x => x.ID == id);
    return Ok(produtos);
  }

  [HttpGet]
  [Route("categorias/{id:int}")]
  [Authorize(Roles="0")]
  public async Task<ActionResult<PRODUTO>> GetByCategoria([FromServices] DataContext context,int id)
  {
    var produtos = await context
    .PRODUTOS
    .Include(x => x.CATEGORIA)
    .AsNoTracking()
    .Where(x => x.CATEGORIA.ID == id).ToListAsync();
    
    return Ok(produtos);
  }

  [HttpPost]
  [Route("")]
  [Authorize(Roles="0")]
  public async Task<ActionResult<List<PRODUTO>>> Post([FromBody]PRODUTO model, [FromServices] DataContext context)
  {

    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    try
    {
      context.PRODUTOS.Add(model);
      await context.SaveChangesAsync();
      return Ok(model);
    }
    catch
    {
      return BadRequest(new { message = "Não foi possivel criar a Produto" });
    }

  }

  [HttpPut]
  [Route("{id:int}")]
  [Authorize(Roles="0")]
  public async Task<ActionResult<List<PRODUTO>>> Put(int id, [FromBody]PRODUTO model, [FromServices] DataContext context)
  {

    if (id != model.ID)
      return NotFound(new { message = "Produto não encontrada" });

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
      return BadRequest(new { message = "Este registro já foi atualizado" });

    }
    catch
    {
      return BadRequest(new { message = "Não foi possivel atualizar a Produto" });

    }

  }

  [HttpDelete]
  [Route("{id:int}")]
  [Authorize(Roles="0")]
  public async Task<ActionResult<List<PRODUTO>>> Delete(int id, [FromServices] DataContext context)
  {
    var produto = await context.PRODUTOS.FirstOrDefaultAsync(x => x.ID == id);
    if (produto == null)
    {
      return NotFound(new { message = "Produto não encontrado" });
    }

    try
    {

      context.PRODUTOS.Remove(produto);
      await context.SaveChangesAsync();
      return Ok(new { message = "Produto removido com sucesso" });

    }
    catch
    {
      return BadRequest(new { message = "Não foi possivel deletar o Produto" });

    }

  }

}