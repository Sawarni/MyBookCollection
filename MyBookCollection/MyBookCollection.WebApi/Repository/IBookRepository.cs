using MyBookCollection.WebApi.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookCollection.WebApi.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();

        Task<IEnumerable<Book>> SearchBooks(string bookName);

        Task<Book> GetBookById(int id);

        Task<Book> UpdateBook(Book book);

        Task<Book> AddBook(Book book);

        Task<bool> DeleteBook(int id);

    }
}
