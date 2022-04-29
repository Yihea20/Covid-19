using Accounts_5.IRepository;
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
    public class NewsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<NewsController> _logger;

        public NewsController(IUnitOfWork unitOfWork, ILogger<NewsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetNews()
        {
            try
            {
                var news = await _unitOfWork.Newses.GetAll();
                return Ok(news);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Want Wrong in the {nameof(GetNews)}");
                return StatusCode(500, "Internal Server Error, Please Try Again Later.");
            }
        }
    }
}
