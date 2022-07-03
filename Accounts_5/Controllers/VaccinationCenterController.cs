using Accounts_5.Data;
using Accounts_5.IRepository;
using Accounts_5.Models;
using Accounts_5.Rebository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    public class VaccinationCenterController:BaseController<VaccinationCenter,CreateVaccinationCenterDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<VaccinationCenter> _logger;
        private readonly IMapper _mapper;
        public VaccinationCenterController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<VaccinationCenter> logger) 
            : base(unitOfWork, mapper, logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet]
        [Route("Statistic")]
        public async Task<IActionResult> Get_Statistics(string address)
        {
            var statistic = await _unitOfWork.person_vaccinationcenter.GetAll(q => q.VaccinationCenter.Address==address);
            var number = statistic.Count;
            return Ok(number);
        }
    }
}
