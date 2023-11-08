using AutoMapper;
using MusicLike.Models.Users.Dto;
using MusicLike.Models.Users;
using MusicLike.Repositories;
using System.Net;
using System.Web.Http;

namespace MusicLike.Services
{

    public class UserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        private readonly IEncoderService _encoderService;
        private readonly ICountryRepository _countryRepo;
        private readonly IGenderRepository _genderRepo;
        private readonly IUserTypeRepository _userTypeRepo;

        public UserService(IUserRepository userRepo, IMapper mapper, IEncoderService encoderService, ICountryRepository countryRepository, IGenderRepository genderRepository, IUserTypeRepository userTypeRepository)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _encoderService = encoderService;
            _countryRepo = countryRepository;
            _genderRepo = genderRepository;
            _userTypeRepo = userTypeRepository;
        }

        private async Task<Users> GetOneByIdOrException(int id)
        {
            var user = await _userRepo.GetOne(u => u.Id == id);

            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return user;
        }

        public async Task<List<UsersDto>> GetAll()
        {
            var lista = await _userRepo.GetAll();
            return _mapper.Map<List<UsersDto>>(lista);
        }
        public async Task<UsersDto> GetById(int id)
        {
            var user = await GetOneByIdOrException(id);
            if (user != null)
            {
                user.Country = await _countryRepo.GetByIdAsync(user.CountryId);
                user.Gender = await _genderRepo.GetByIdAsync(user.GenderId);
                user.UserType = await _userTypeRepo.GetByIdAsync(user.UserTypeId);
            }

            var mapped = _mapper.Map<UsersDto>(user);

            return mapped;
        }
        public async Task<Users> GetByUsernameOrEmail(string? username)
        {
            Users user = await _userRepo.GetOne(u => u.UserName == username); ;

            if (user != null)
            {
                user.Country = await _countryRepo.GetByIdAsync(user.CountryId);
                user.Gender = await _genderRepo.GetByIdAsync(user.GenderId);
                user.UserType = await _userTypeRepo.GetByIdAsync(user.UserTypeId);
            }

            return user;
        }
        public async Task<List<UsersDto>> GetAllWithRelatedData()
        {
            var users = await _userRepo.GetAllWithRelatedData(); 

            return _mapper.Map<List<UsersDto>>(users);
        }

        public async Task<CreateResponseDto> Create(CreateUser createUserDto)
        {
            var user = _mapper.Map<Users>(createUserDto);

            user.Password = _encoderService.Encode(user.Password);

            await _userRepo.Add(user);

            return _mapper.Map<CreateResponseDto>(user);
        }
        public async Task<UpdateDto> UpdateById(int id, UpdateDto updateUserDto)
        {
            var user = await GetOneByIdOrException(id);

            var updated = _mapper.Map(updateUserDto, user);

            return _mapper.Map<UpdateDto>(await _userRepo.Update(updated));
        }

        public async Task DeleteById(int id)
        {
            var user = await GetOneByIdOrException(id);

            await _userRepo.Delete(user);
        }

    }
}
