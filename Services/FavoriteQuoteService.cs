namespace backend.Services;

using AutoMapper;
using backend.Entities;
using backend.Helpers;
using backend.Models.FavoriteQuotes;

public interface IFavoriteQuoteService
{
    void Create(CreateFavoriteQuoteRequest model);
    void Delete(int id);
}

public class FavoriteQuoteService : IFavoriteQuoteService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public FavoriteQuoteService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Create(CreateFavoriteQuoteRequest model)
    {
        // map model to new favoriteQuote object
        var favoriteQuote = _mapper.Map<FavoriteQuote>(model);

        // save favoriteQuote
        _context.FavoriteQuotes.Add(favoriteQuote);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var favoriteQuote = getFavoriteQuote(id);
        _context.FavoriteQuotes.Remove(favoriteQuote);
        _context.SaveChanges();
    }

    // helper methods
    private FavoriteQuote getFavoriteQuote(int id)
    {
        var favoriteQuote = _context.FavoriteQuotes.Find(id);
        if (favoriteQuote == null) throw new KeyNotFoundException("Favorite quote not found");
        return favoriteQuote;
    }
}