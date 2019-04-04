using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDb.Model;
using MongoDb.service;

namespace MongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;
        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            return _bookService.Get();
        }
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(string id)
        {
            var book = _bookService.Get(id);
            if (book==null)
            {
                return NotFound();
            }
            return book;
        }
        [HttpPost("test")]
        public ActionResult<Book> Create( Book book)
        {
            _bookService.Create(book);
            return CreatedAtAction("GetBook",new { id=book.Id},book);
        }
    }
}