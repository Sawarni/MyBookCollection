using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyBookCollection.WebApi.Database;
using MyBookCollection.WebApi.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookCollection.WebApi.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<BookRepository> logger;

        public BookRepository(ApplicationDbContext context, ILogger<BookRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public async Task<Book> AddBook(Book book)
        {
            context.Add(book);
            var result = await context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var book = await context.Books.FindAsync( id);
            if(book != null)
            {
                context.Books.Remove(book);
                var result = await context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<Book> GetBookById(int id)
        {
            var book = await context.Books.FindAsync(id);
            return book;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            var books = await context.Books
                //.Include(x=> x.Characters).Include(x=>x.BookType).Include(x=>x.Publisher).Include(x=>x.Authors)
                .ToListAsync();
            return books;
        }

        public async Task<IEnumerable<Book>> SearchBooks(string bookName)
        {
            var books =  context.Books.Where(x=>x.BookName.Contains(bookName));
            return await books.ToListAsync();
        }

        public async Task<Book> UpdateBook(Book book)
        {
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
            return book;
        }
    }
}
