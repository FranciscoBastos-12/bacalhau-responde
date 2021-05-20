using AutoMapper;
using Core.Exceptions;
using Domain.Entities;
using Infra.Interfaces;
using Services.Dto;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDto> Create(UserDto userDto)
        {
            var userAlreadyExists = await _userRepository.GetByEmail(userDto.Email);
            if (userAlreadyExists != null)
            {
                throw new DomainException("Já existe um usuário com o email informado");
            }
            var user = _mapper.Map<User>(userDto);
            user.Validate();

            var userCreated  = await _userRepository.Create(user);
            return _mapper.Map<UserDto>(userCreated);
        }

        public async Task<UserDto> Update(UserDto userDto)
        {
            var userAlreadyExists = await _userRepository.GetById(userDto.Id);
            if (userAlreadyExists == null)
            {
                throw new DomainException("Não existe usuário com este ID informado");
            }
            var user = _mapper.Map<User>(userDto);
            user.Validate();

            var userUpdated = await _userRepository.Update(user);
            return _mapper.Map<UserDto>(userUpdated);
        }

        public async Task Remove(long id)
        {
            await _userRepository.Remove(id);
        }

        public async Task<UserDto> GetById(long id)
        {
            var user = await _userRepository.GetById(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<List<UserDto>> List()
        {
            var userList = await _userRepository.List();
            return _mapper.Map<List<UserDto>>(userList);
        }

        public async Task<UserDto> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<List<UserDto>> SearchByEmail(string email)
        {
            var userList = await _userRepository.SearchByEmail(email);
            return _mapper.Map<List<UserDto>>(userList);
        }

        public async Task<List<UserDto>> SearchByName(string name)
        {
            var userList = await _userRepository.SearchByName(name);
            return _mapper.Map<List<UserDto>>(userList);
        }
    }
}
