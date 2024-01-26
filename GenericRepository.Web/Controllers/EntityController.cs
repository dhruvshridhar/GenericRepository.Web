using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericRepository.Web.Entities;
using GenericRepository.Web.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepository.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        private readonly IGenericRepository<Book> bookRepository;
        private readonly IGenericRepository<Author> authorRepository;

        public EntityController(IGenericRepository<Book> bookRepository, IGenericRepository<Author> authorRepository)
        {
            this.bookRepository = bookRepository;
            this.authorRepository = authorRepository;
        }

        [HttpGet]
        [Route("books")]
        public async Task<ActionResult> GetBooks()
        {
            var result = bookRepository.GetAll().ToList();
            return Ok(result);
        }
    }
}
