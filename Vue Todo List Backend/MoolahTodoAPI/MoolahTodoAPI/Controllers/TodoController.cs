using Microsoft.AspNetCore.Mvc;
using MoolahTodoAPI.Data;
using MoolahTodoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MoolahTodoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TodoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos([FromQuery] string? search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return await _context.Todos.ToListAsync();
            }

            return await _context.Todos
                .Where(t => t.Name.ToLower().Contains(search.ToLower()))
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> AddTodo(Todo todo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(todo.Name))
                {
                    return BadRequest("Task name cannot be empty.");
                }

                todo.Tag ??= "";
                _context.Todos.Add(todo);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetTodos), new { id = todo.Id }, todo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, Todo updatedTodo)
        {
            if (id != updatedTodo.Id)
                return BadRequest();

            _context.Entry(updatedTodo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
