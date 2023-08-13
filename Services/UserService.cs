namespace backend.Services;

using AutoMapper;
using backend.Entities;
using backend.Helpers;
using backend.Models.Users;

public interface IUserService
{
    IEnumerable<User> GetAll();
    User GetById(int id);
    User GetByUsername(string username);
    bool UserExists(string username);
    void Create(CreateUserRequest model);
    void Update(int id, UpdateUserRequest model);
    void Delete(int id);
}

public class UserService : IUserService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UserService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users;
    }

    public User GetById(int id)
    {
        return getUser(id);
    }

    public User GetByUsername(string username)
    {
        return _context.Users.FirstOrDefault(u => u.Username == username);
    }

    public bool UserExists(string username)
    {
        var user = _context.Users.FirstOrDefault(u => u.Username == username);
        return user != null;
    }

    public void Create(CreateUserRequest model)
    {
        // map model to user object
        var user = _mapper.Map<User>(model);
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void Update(int id, UpdateUserRequest model)
    {
        var user = getUser(id);

        // copy model to user and save
        _mapper.Map(model, user);
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var user = getUser(id);
        _context.Users.Remove(user);
        _context.SaveChanges();
    }

    // helper methods
    private User getUser(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }
}