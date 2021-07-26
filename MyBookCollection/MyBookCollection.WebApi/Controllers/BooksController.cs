using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        public BooksController(ILogger<BooksController> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            this.bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetBooks()
        {
            return Ok(await bookRepository.GetBooks());
        }
    }
}
