namespace backend.Services;

using AutoMapper;
using backend.Entities;
using backend.Helpers;
using backend.Models.Quotes;

public interface IQuoteService
{
    IEnumerable<QuoteResponse> GetAll(int loggedInUserId);
    Quote GetById(int id);
    void Create(CreateQuoteRequest model);
    void Update(int id, UpdateQuoteRequest model);
    void Delete(int id);
}

public class QuoteService : IQuoteService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public QuoteService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<QuoteResponse> GetAll(int loggedInUserId)
    {
        var quotesWithUsernames = _context.Quotes
         .OrderByDescending(x => x.CreatedAt)
         .Join(_context.Users,
               quote => quote.UserId,
               user => user.Id,
               (quote, user) => new
               {
                   Quote = quote,
                   user.Id,
                   user.Username
               })
         .Select(result => new QuoteResponse
         {
             Id = result.Quote.Id,
             Value = result.Quote.Value,
             From = result.Quote.From,
             UserId = result.Id,
             Username = result.Username,
             FavoriteQuoteId = _context.FavoriteQuotes.FirstOrDefault(fq => fq.UserId == loggedInUserId && fq.QuoteId == result.Quote.Id).Id
         });

        return quotesWithUsernames;
    }

    public Quote GetById(int id)
    {
        return getQuote(id);
    }

    public void Create(CreateQuoteRequest model)
    {
        // map model to new quote object
        var quote = _mapper.Map<Quote>(model);


        // save quote
        _context.Quotes.Add(quote);
        _context.SaveChanges();
    }

    public void Update(int id, UpdateQuoteRequest model)
    {
        var quote = getQuote(id);

        // copy model to quote and save
        _mapper.Map(model, quote);
        _context.Quotes.Update(quote);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var quote = getQuote(id);
        _context.Quotes.Remove(quote);
        _context.SaveChanges();
    }

    // helper methods
    private Quote getQuote(int id)
    {
        var quote = _context.Quotes.Find(id);
        if (quote == null) throw new KeyNotFoundException("quote not found");
        return quote;
    }
}