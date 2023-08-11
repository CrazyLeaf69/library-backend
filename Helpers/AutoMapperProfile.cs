namespace backend.Helpers;

using AutoMapper;
using backend.Entities;
using backend.Models.Auth;
using backend.Models.Books;
using backend.Models.Users;
using backend.Models.Quotes;
using backend.Models.FavoriteQuotes;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // CreateRequest -> User
        CreateMap<CreateUserRequest, User>();

        // UpdateRequest -> User
        CreateMap<UpdateUserRequest, User>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore both null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    return true;
                }
            ));

        CreateMap<RegisterRequest, CreateUserRequest>();
        CreateMap<CreateBookRequest, Book>();
        CreateMap<UpdateBookRequest, Book>();
        CreateMap<CreateQuoteRequest, Quote>();
        CreateMap<UpdateQuoteRequest, Quote>();
        CreateMap<CreateFavoriteQuoteRequest, FavoriteQuote>();
    }
}