using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Model;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemController : ControllerBase
    {
        private readonly AppDbContext _context;
       

        public TodoItemController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todoItems = await _context.TodoItems.ToListAsync();

            return Ok(todoItems);
        }


        [HttpPost]
        public async Task<IActionResult> Create(TodoItem todoItem)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _context.AddAsync(todoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), todoItem);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TodoItem newTodoItem)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var existingTodoItem = await _context.TodoItems.FindAsync(id);

            if(existingTodoItem == null)
            {
                return NotFound();
            }

            existingTodoItem.Title = newTodoItem.Title;
            existingTodoItem.Completed = newTodoItem.Completed;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if(todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
