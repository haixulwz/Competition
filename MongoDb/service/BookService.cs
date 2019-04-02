using Microsoft.Extensions.Configuration;
using MongoDb.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDb.service
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _book;
        public BookService(IConfiguration configuration)
        {
            var client = new MongoClient( configuration.GetConnectionString("BookstoreDb"));
            var database = client.GetDatabase("BookstoreDb");
            _book = database.GetCollection<Book>("Books");

        }
        public List<Book> Get()
        {
            return _book.Find(b=>true).ToList();
        }

        public Book Get(string id)
        {
            return _book.Find<Book>(book => book.Id == id).FirstOrDefault();
        }
        public Book Create(Book book)
        {
            _book.InsertOne(book);
            return book;
        }

        public void Update(string id, Book bookIn)
        {
            _book.ReplaceOne(book => book.Id == id, bookIn);
        }

        public void Remove(Book bookIn)
        {
            _book.DeleteOne(book => book.Id == bookIn.Id);
        }
    }
}
