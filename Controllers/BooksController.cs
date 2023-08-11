namespace backend.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using backend.Models.Books;
using backend.Services;

[ApiController]
[Authorize]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var books = _bookService.GetAll();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var book = _bookService.GetById(id);
        return Ok(book);
    }

    [HttpPost]
    public IActionResult Create(CreateBookRequest model)
    {
        _bookService.Create(model);
        return Ok(new { message = "Book created" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateBookRequest model)
    {
        _bookService.Update(id, model);
        return Ok(new { message = "Book updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _bookService.Delete(id);
        return Ok(new { message = "Book deleted" });
    }
}