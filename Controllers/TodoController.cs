using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoBackend.Data;
using TodoBackend.Models;
using TodoBackend.ViewModels;

namespace TodoBackend.Controllers;

[ApiController]
[Route("v1")]
public class TodoController : ControllerBase
{
    [HttpGet]
    [Route("todos")]
    public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
    {
        var todos = await context.Todos.AsNoTracking().ToListAsync();
        return Ok(todos);
    }
    
    [HttpGet]
    [Route("todos/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromServices] AppDbContext context, [FromRoute] int id)
    {
        var todo = await context.Todos.AsNoTracking().FirstOrDefaultAsync((x => x.Id == id));
        return todo == null ? NotFound() : Ok(todo);
    }
    
    [HttpPost("todos")]
    public async Task<IActionResult> PostAsync([FromServices] AppDbContext context, [FromBody] CreateTodoViewModel model)
    {
        if (!ModelState.IsValid) return BadRequest();

        try
        {

            var todo = new Todo
            {
                CreatedAt = DateTime.Now,
                Done = false,
                Title = model.Title
            };

            await context.Todos.AddAsync(todo);
            await context.SaveChangesAsync();

            return Created($"v1/todos/{todo.Id}", todo);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

    }

    [HttpPut("todos/{id}")]
    public async Task<IActionResult> PutAsync([FromServices] AppDbContext context, [FromRoute] int id,[FromBody] CreateTodoViewModel model)
    {
        if (!ModelState.IsValid) return BadRequest();
        
        try
        {

            var todo = await context.Todos.FirstOrDefaultAsync(x => x.Id == id);

            if (todo == null) return NotFound();

            todo.Title = model.Title;

            context.Todos.Update(todo);
            await context.SaveChangesAsync();

            return Ok( todo);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("todos/{id}")]
    public async Task<IActionResult> DeleteAsync([FromServices] AppDbContext context, [FromRoute] int id)
    {
        if (!ModelState.IsValid) return BadRequest();

        try
        {
            var todo = await context.Todos.FirstOrDefaultAsync(x => x.Id == id);

            if (todo == null) return NotFound();

            context.Todos.Remove(todo);

            await context.SaveChangesAsync();

            return Ok();

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}