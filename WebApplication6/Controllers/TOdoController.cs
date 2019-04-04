using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TOdoController : ControllerBase
    {
        private readonly TodoContext _context;
        public TOdoController(TodoContext context)
        {
            _context = context;
            if (_context.TodoItems.Count()==0)
            {
                _context.TodoItems.Add(new TodoItem { Name="itme1"});
                _context.SaveChanges();
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {

            return await _context.TodoItems.ToListAsync();
        }





        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var todoItem= await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem; 
                
        }
        [HttpPost("test")]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem item)
        {
            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTodoItem),new { id=item.Id},item);
        }
    }
}