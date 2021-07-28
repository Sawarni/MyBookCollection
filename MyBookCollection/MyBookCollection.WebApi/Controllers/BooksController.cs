using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBookCollection.Models;
using MyBookCollection.WebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookCollection.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {

        private readonly ILogger<BooksController> _logger;
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;

        public BooksController(ILogger<BooksController> logger, IBookRepository bookRepository, IMapper mapper)
        {
            _logger = logger;
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetBooks()
        {
            var books = await bookRepository.GetBooks();
            var bookDtos = mapper.Map<IEnumerable<BookDto>>(books);
            return Ok(bookDtos);
        }
    }
}
