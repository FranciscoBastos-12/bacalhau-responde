using Application.Utilities;
using Application.ViewModels;
using AutoMapper;
using Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.Dto;
using Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        [Route("/api/users/get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listUsers = await _userService.List();

                return Ok(new ResultViewModel
                {
                    Message = "Usuários encontrados com sucesso.",
                    Success = true,
                    Data = listUsers
                });
            }
            catch (DomainException dex)
            {
                return BadRequest(Responses.DomainErrorMessage(dex.Message, dex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPost]
        [Route("/api/users/create")]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
        {
            try
            {
                var userDto = _mapper.Map<UserDto>(userViewModel);
                var userCreated = await _userService.Create(userDto);
                return Ok(new ResultViewModel
                {
                    Message = "Usuário criado com sucesso",
                    Success = true,
                    Data = userCreated
                });
            }
            catch (DomainException dex)
            {
                return BadRequest(Responses.DomainErrorMessage(dex.Message, dex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPut]
        [Route("/api/users/update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserViewModel userViewModel)
        {
            try
            {
                var userDto = _mapper.Map<UserDto>(userViewModel);
                var userUpdated = await _userService.Update(userDto);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário atualizado com sucesso.",
                    Success = true,
                    Data = userUpdated
                });
            }
            catch (DomainException dex)
            {
                return BadRequest(Responses.DomainErrorMessage(dex.Message, dex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpDelete]
        [Route("/api/users/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _userService.Remove(id);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário removido com sucesso.",
                    Success = true,
                    Data = null
                });
            }
            catch (DomainException dex)
            {
                return BadRequest(Responses.DomainErrorMessage(dex.Message, dex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/users/get-by-id/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var user = await _userService.GetById(id);

                if (user == null)
                {
                    return BadRequest(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado com o ID informado.",
                        Success = false,
                        Data = null
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso.",
                    Success = true,
                    Data = user
                });
            }
            catch (DomainException dex)
            {
                return BadRequest(Responses.DomainErrorMessage(dex.Message, dex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/users/get-by-email")]
        public async Task<IActionResult> GetByEmail([FromQuery] string email)
        {
            try
            {
                var user = await _userService.GetByEmail(email);

                if (user == null)
                {
                    return BadRequest(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado com o email informado.",
                        Success = false,
                        Data = null
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso.",
                    Success = true,
                    Data = user
                });
            }
            catch (DomainException dex)
            {
                return BadRequest(Responses.DomainErrorMessage(dex.Message, dex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/users/search-by-name")]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            try
            {
                var user = await _userService.SearchByName(name);

                if (user == null)
                {
                    return BadRequest(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado com o nome informado.",
                        Success = false,
                        Data = null
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso.",
                    Success = true,
                    Data = user
                });
            }
            catch (DomainException dex)
            {
                return BadRequest(Responses.DomainErrorMessage(dex.Message, dex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/users/search-by-email")]
        public async Task<IActionResult> SearchByEmail([FromQuery] string email)
        {
            try
            {
                var user = await _userService.SearchByEmail(email);

                if (user == null)
                {
                    return BadRequest(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado com o email informado.",
                        Success = false,
                        Data = null
                    });
                }

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso.",
                    Success = true,
                    Data = user
                });
            }
            catch (DomainException dex)
            {
                return BadRequest(Responses.DomainErrorMessage(dex.Message, dex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}
