namespace backend.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using backend.Models.Quotes;
using backend.Models.FavoriteQuotes;
using backend.Services;

[ApiController]
[Authorize]
[Route("[controller]")]
public class QuotesController : ControllerBase
{
    private readonly IQuoteService _quoteService;
    private readonly IFavoriteQuoteService _favoriteQuoteService;

    public QuotesController(IQuoteService quoteService, IFavoriteQuoteService favoriteQuoteService)
    {
        _quoteService = quoteService;
        _favoriteQuoteService = favoriteQuoteService;
    }

    [HttpGet]
    public IActionResult GetAll([FromQuery] int userId)
    {
        var quotes = _quoteService.GetAll(userId);
        return Ok(quotes);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var quote = _quoteService.GetById(id);
        return Ok(quote);
    }

    [HttpPost]
    public IActionResult Create(CreateQuoteRequest model)
    {
        _quoteService.Create(model);
        return Ok(new { message = "Quote created" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateQuoteRequest model)
    {
        _quoteService.Update(id, model);
        return Ok(new { message = "Quote updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _quoteService.Delete(id);
        return Ok(new { message = "Quote deleted" });
    }

    [HttpPost("favorite")]
    public IActionResult Favorite(CreateFavoriteQuoteRequest model)
    {
        _favoriteQuoteService.Create(model);
        return Ok(new { message = "Quote favourited" });
    }
    [HttpPost("unfavorite")]
    public IActionResult Favorite(DeleteFavoriteQuoteRequest model)
    {
        _favoriteQuoteService.Delete(model.FavoriteQuoteId);
        return Ok(new { message = "Quote unfavourited" });
    }
}