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
    public class BaseController<T, C> : ControllerBase where T : class where C : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<T> _logger;
        private readonly IMapper _mapper;

        public BaseController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<T> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;

        }

        [HttpPost]
        [Route("post")]
        public async Task<IActionResult> Create([FromBody] C newsDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempd in {nameof(Create)}");
                return BadRequest(ModelState);
            }
            if (typeof(T) == typeof(VaccinationCenter))
            {
                var news = _mapper.Map<VaccinationCenter>(newsDTO);
                await _unitOfWork.VaccinationCenters.Insert(news);
                await _unitOfWork.Save();
                return Ok();
            }
            else if (typeof(T) == typeof(News))
            {
                var news = _mapper.Map<News>(newsDTO);
                await _unitOfWork.Newses.Insert(news);
                await _unitOfWork.Save();
                return Ok();
            }
            else if (typeof(T) == typeof(Vaccination))
            {
                var news = _mapper.Map<Vaccination>(newsDTO);
                await _unitOfWork.Vaccinaions.Insert(news);
                await _unitOfWork.Save();
                return Ok();
            }
            return NoContent();
        }
    
      
        [HttpGet]
        public async Task<IActionResult> Get_All()
        {
                if (typeof(T) == typeof(VaccinationCenter))
                {
                    var newses = await _unitOfWork.VaccinationCenters.GetAll(include: q => q.Include(x => x.Vaccinations));
                    var result = _mapper.Map<IList<VaccinationCenterDTO>>(newses);
                    return Ok(result);
                }
                else if(typeof(T)==typeof(News))
                {
                    var newses = await _unitOfWork.Newses.GetAll();
                    var result = _mapper.Map<IList<NewsDTO>>(newses);
                    return Ok(result);
                }
                else if (typeof(T) == typeof(Vaccination))
                {
                    var newses = await _unitOfWork.Vaccinaions.GetAll(includee:q=>q.Include(x=>x.VaccinationCenter));
                    var result = _mapper.Map<IList<VaccinationDTO>>(newses);
                    return Ok(result);
                }
                return NoContent();  
        }
        [HttpGet("{id:int}")]
       // [Route("Get_Center_By_Id")]
        public async Task<IActionResult> Get_by_Id( int id)
        {
                if (typeof(T) == typeof(VaccinationCenter))
                {
                    var news = await _unitOfWork.VaccinationCenters.Get(q => q.Id == id, include: q => q.Include(x => x.Vaccinations)
                    ,includee:q=>q.Include(x=>x.Person));
                    var result = _mapper.Map<VaccinationCenterDTO>(news);
                    return Ok(news);
                }
                else if (typeof(T) == typeof(News))
                {
                    var news = await _unitOfWork.Newses.Get(q => q.Id == id);
                    var result = _mapper.Map<NewsDTO>(news);
                    return Ok(news);
                }
                else if (typeof(T) == typeof(Vaccination))
                {
                    var news = await _unitOfWork.Vaccinaions.Get(q => q.Id == id, include: q => q.Include(x => x.VaccinationCenter)
                    ,includee:q=>q.Include(x=>x.Person));
                    var result = _mapper.Map<VaccinationDTO>(news);
                    return Ok(news);
                }
                else
                    return NoContent();
            }
        [HttpPut]
        public async Task<IActionResult> Update(int id,C vaccinationCenterDTO)
        {
                if (typeof(T) == typeof(VaccinationCenter))
                {
                    var old = await _unitOfWork.VaccinationCenters.Get(q => q.Id == id);
                    _mapper.Map(vaccinationCenterDTO, old);
                    _unitOfWork.VaccinationCenters.Update(old);
                    await _unitOfWork.Save();
                    return NoContent();
                }
                else if(typeof(T)==typeof(News))
                {
                    var old = await _unitOfWork.Newses.Get(q => q.Id == id);
                    _mapper.Map(vaccinationCenterDTO, old);
                    _unitOfWork.Newses.Update(old);
                    await _unitOfWork.Save();
                    return NoContent();
                }
                else if (typeof(T) == typeof(Vaccination))
                {
                    var old = await _unitOfWork.Vaccinaions.Get(q => q.Id == id);
                    _mapper.Map(vaccinationCenterDTO, old);
                    _unitOfWork.Vaccinaions.Update(old);
                    await _unitOfWork.Save();
                    return NoContent();
                }
                return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult>Delete(int id)
        {
                if (typeof(T) == typeof(VaccinationCenter))
                {
                    await _unitOfWork.VaccinationCenters.Delete(id);
                    await _unitOfWork.Save();
                    return NoContent();
                }
               else if (typeof(T) == typeof(News))
                {
                    await _unitOfWork.Newses.Delete(id);
                    await _unitOfWork.Save();
                    return NoContent();
                }
                else if (typeof(T) == typeof(Vaccination))
                {
                    await _unitOfWork.Vaccinaions.Delete(id);
                    await _unitOfWork.Save();
                    return NoContent();
                }
                return Ok();

         
        }
    }
}
