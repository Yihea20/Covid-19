using Accounts_5.Data;
using Accounts_5.IRepository;
using Accounts_5.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinationController : BaseController<Vaccination, CreateVaccinationDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<Vaccination> _logger;
        private readonly IMapper _mapper;
        public VaccinationController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Vaccination> logger) : base(unitOfWork, mapper,logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;

        }
        [HttpPut]
        [Route("Add_Vaccination_To_Center")]
        public async Task<IActionResult> Add_Vaccination_TO_Center(Vaccinaion_vaccinationCenterDTO vaccinaion_VaccinationCenterDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Connicion attempd in {nameof(Add_Vaccination_TO_Center)}");
                return BadRequest(ModelState);
            }
            try
            {
                var vvc = _mapper.Map<VaccinationCenter_Vaccination>(vaccinaion_VaccinationCenterDTO);
                await _unitOfWork.Vaccination_VaccinationCenters.Insert(vvc);
                await _unitOfWork.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Want Wrong in the {nameof(Add_Vaccination_TO_Center)}");
                return StatusCode(500, "Internal Server Error, Please Try Again Later.");
            }
        }
        
        [HttpPut]
        [Route("Take_Vaccination_from_Center")]
        public async Task<IActionResult> Take_Vaccination_From_Center(int centerId,[FromBody]Person_VaccinationDTO person_VaccinationDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Connicion attempd in {nameof(Take_Vaccination_From_Center)}");
                return BadRequest(ModelState);
            }
            try
            {
                Person_VaccinationCenter person_VaccinationCenter = new Person_VaccinationCenter()
                {
                    PersonId = person_VaccinationDTO.PersonId,
                    VaccinationCenterId = centerId
                };
                var pv = _mapper.Map<Person_Vaccination>(person_VaccinationDTO);
                await _unitOfWork.person_vaccination.Insert(pv);
                await _unitOfWork.Save();
                await _unitOfWork.person_vaccinationcenter.Insert(person_VaccinationCenter);
                await _unitOfWork.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Want Wrong in the {nameof(Take_Vaccination_From_Center)}");
                return StatusCode(500, "Internal Server Error, Please Try Again Later.");
            }
        }
    }
}
