using AutoMapper;
using MusicLike.Models.Users.Dto;
using MusicLike.Models.Users;
using MusicLike.Models.Country.Dto;
using MusicLike.Models.Gender.Dto;
using MusicLike.Models.UserType.Dto;
using MusicLike.Models.UserType;
using MusicLike.Models.Gender;
using MusicLike.Models.Country;
using MusicLike.Models.Artists.Dto;
using MusicLike.Models.Artists;
using MusicLike.Models.Releases.Dto;
using MusicLike.Models.Releases;
using MusicLike.Models.Genres.GenresDto;
using MusicLike.Models.Genres;

namespace MusicLike.Config
{
    public class Mapping : Profile
    {
        public Mapping() 
        {
            CreateMap<Users, CreateResponseDto>().ReverseMap();
            CreateMap<Users, UsersDto>()
                .ForMember(dest => dest.UserType, opt => opt.MapFrom(src => new UserTypeDto { Id = src.UserType.Id, Name = src.UserType.Name }))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => new GenderDto { Id = src.Gender.Id, Name = src.Gender.Name }))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => new CountryDto { Id = src.Country.Id, Name = src.Country.Name }))
                .ReverseMap();
            CreateMap<Users, LoginUser>().ReverseMap();
            CreateMap<Users, LoginResponse>().ReverseMap();
            CreateMap<CreateUser, Users>().ReverseMap();
            CreateMap<UserTypeDto, UserType>().ReverseMap();
            CreateMap<GenderDto, Gender>().ReverseMap();
            CreateMap<CountryDto, Country>().ReverseMap();
            CreateMap<UpdateDto, Users>().ReverseMap();
            CreateMap<CreateArtistDto, Artist>().ReverseMap();
            CreateMap<Artist, ArtistDto>().ReverseMap();
            CreateMap<Artist, CreateArtistResponseDto>().ReverseMap();
            CreateMap<CreateArtistResponseDto, Artist>().ReverseMap();
            CreateMap<ArtistUpdateDto, Artist>().ReverseMap();
            CreateMap<Artist, ArtistUpdateDto>().ReverseMap();
            CreateMap<CreateReleaseDto, Releases>().ReverseMap();
            CreateMap<GenresDto, Genres>().ReverseMap();
            CreateMap<ReleaseUpdateDto, Releases>().ReverseMap();
            CreateMap<ReleaseUpdateDto, ReleasesDto>().ReverseMap();
            //CreateMap<CreateReleaseDto, Releases>().ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres));

        }
    }
}
