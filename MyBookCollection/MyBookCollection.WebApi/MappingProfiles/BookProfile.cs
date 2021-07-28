using AutoMapper;
using MyBookCollection.Models;
using MyBookCollection.WebApi.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookCollection.WebApi.MappingProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>();
        }

    }

    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDto>();
        }

    }

    public class BookTypeProfile : Profile
    {
        public BookTypeProfile()
        {
            CreateMap<BookType, BookTypeDto>();
        }

    }


    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<Character, CharacterDto>();
        }

    }


    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher, PublisherDto>();
        }

    }

}
