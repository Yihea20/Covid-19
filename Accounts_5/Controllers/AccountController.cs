using Accounts_5.Data;
using Accounts_5.IRepository;
using Accounts_5.Models;
using Accounts_5.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts_5.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<Person> _userManager;
        private readonly ILogger<AccountsController> _logger;
        private readonly IAuthoManger _authoManger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public AccountsController(UserManager<Person> userManager, ILogger<AccountsController> logger
            , IMapper mapper,IAuthoManger authoManger,IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
            _authoManger = authoManger;
            _unitOfWork = unitOfWork;
        }
      [HttpPost]
        [Route("Regis")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] PersonDTO personDTO)
        {
            _logger.LogInformation($"Registerstion Attempt for {personDTO.id}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = _mapper.Map<Person>(personDTO);
                user.UserName = personDTO.id;
                user.Email = $"{personDTO.id}@gmail.com";
                var result = await _userManager.CreateAsync(user,personDTO.Password);
                //result = await _userManager.AddPasswordAsync(user,);
                if (!result.Succeeded)
                {
                    foreach (var Error in result.Errors)
                    {
                        ModelState.AddModelError(Error.Code, Error.Description);
                        
                    }
                    return BadRequest(ModelState);
                }
                await _userManager.AddToRolesAsync(user, personDTO.roleName);
               
                return Ok($"StatusCode:{StatusCodes.Status202Accepted}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"somthging went wrong in the {nameof(Register)}");
                return Problem($"somthging went wrong in the {nameof(Register)}");
            }
        }
       [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginPersonDTO personDTO)
        {
            _logger.LogInformation($"Registerstion Attempt for {personDTO.id}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (!await _authoManger.ValidateUser(personDTO))
                {
                    return Unauthorized();
                }
                Random rnd = new Random();
                int myRandomNo = rnd.Next(10000000, 99999999);
                var person = await _userManager.FindByIdAsync(personDTO.id) as Person;
                person.PhoneNumber =myRandomNo.ToString();
                await _userManager.UpdateAsync(person);
                return Accepted(new TokenRequest { Token = await _authoManger.CreatToken(), RefreshToken = await _authoManger.CreateRefreshToken(),rand=myRandomNo.ToString() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"somthging went wrong in the {nameof(Login)}");
                return Problem($"somthging went wrong in the {nameof(Login)}");
            }
        }
        [HttpPost]
        [Route("refreshtoken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequest request)
        {
            var tokenRequest = await _authoManger.VerifyRefreshToken(request);
            if (tokenRequest is null)
            {
                return Unauthorized();
            }

            return Ok(tokenRequest);
        }
    
    [HttpPut]
        public async Task<IActionResult> GetAllPerson(Person_VaccinationDTO person_VaccinationDTO)
        {
            try
            {
                //var person = _userManager.Users;
               var person= await _userManager.FindByIdAsync(person_VaccinationDTO.PersonId) as Person ;
                person.isVaccinated =true ;
                await _userManager.UpdateAsync(person);
                var pv = _mapper.Map<Person_Vaccination>(person_VaccinationDTO);
                await _unitOfWork.person_vaccination.Insert(pv);
                await _unitOfWork.Save();
               var Show = _mapper.Map<PersonDTO>(person);
                return Ok(Show);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"somthging went wrong in the {nameof(Login)}");
            return Problem($"somthging went wrong in the {nameof(Login)}");
            }
        }
    }
}
