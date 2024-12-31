using GenericRepository.Web.Entities;
using GenericRepository.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepository.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EntityController : ControllerBase
{
    private readonly IDataService<Book> _bookService;
    private readonly IDataService<Author> _authorService;

    public EntityController(IDataService<Book> bookService, IDataService<Author> authorService)
    {
        _bookService = bookService;
        _authorService = authorService;
    }

    [HttpGet]
    [Route("books")]
    public async Task<ActionResult> GetBooks()
    {
        var result = await _bookService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet]
    [Route("authors")]
    public async Task<ActionResult> GetAuthors()
    {
        var result = await _authorService.GetAllAsync();
        return Ok(result);
    }
}