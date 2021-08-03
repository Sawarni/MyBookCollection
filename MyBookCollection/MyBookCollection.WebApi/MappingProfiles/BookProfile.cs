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
            CreateMap<Book, BookDto>().ReverseMap();
        }

    }

    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
        }

    }

    public class BookTypeProfile : Profile
    {
        public BookTypeProfile()
        {
            CreateMap<BookType, BookTypeDto>().ReverseMap();
        }

    }


    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<Character, CharacterDto>()
                .ForMember(x=> x.ImageFile, cfg=> cfg.MapFrom(y=>y.CharacterImage))
                .ReverseMap();
        }

    }


    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher, PublisherDto>().ReverseMap();
        }

    }

    public class ImageFileProfile:Profile
    {
        public ImageFileProfile()
        {
            CreateMap<ImageFile, ImageFileDto>().ReverseMap();
        }
    }

}
