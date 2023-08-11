namespace backend.Services;

using AutoMapper;
using backend.Entities;
using backend.Helpers;
using backend.Models.Books;

public interface IBookService
{
    IEnumerable<BookResponse> GetAll();
    Book GetById(int id);
    void Create(CreateBookRequest model);
    void Update(int id, UpdateBookRequest model);
    void Delete(int id);
}

public class BookService : IBookService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public BookService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<BookResponse> GetAll()
    {
        var booksWithUsernames = _context.Books
         .OrderByDescending(x => x.CreatedAt)
         .Join(_context.Users,
               book => book.AddedBy,
               user => user.Id,
               (book, user) => new
               {
                   Book = book,
                   user.Username
               })
         .Select(result => new BookResponse
         {
             // Map properties from the joined result
             Id = result.Book.Id,
             Title = result.Book.Title,
             Author = result.Book.Author,
             Description = result.Book.Description,
             PublishedDate = result.Book.PublishedDate,
             AddedBy = result.Username
         });

        return booksWithUsernames;
    }

    public Book GetById(int id)
    {
        return getBook(id);
    }

    public void Create(CreateBookRequest model)
    {
        // map model to new book object
        var book = _mapper.Map<Book>(model);


        // save book
        _context.Books.Add(book);
        _context.SaveChanges();
    }

    public void Update(int id, UpdateBookRequest model)
    {
        var book = getBook(id);

        // copy model to book and save
        _mapper.Map(model, book);
        _context.Books.Update(book);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var book = getBook(id);
        _context.Books.Remove(book);
        _context.SaveChanges();
    }

    // helper methods
    private Book getBook(int id)
    {
        var book = _context.Books.Find(id);
        if (book == null) throw new KeyNotFoundException("book not found");
        return book;
    }
}