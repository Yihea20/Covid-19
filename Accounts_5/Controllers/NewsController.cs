using Accounts_5.Data;
using Accounts_5.IRepository;
using Accounts_5.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    public class NewsController : BaseController<News,CreateNewsDTO>
    {
        public NewsController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<News> logger) : base(unitOfWork, mapper, logger)
        {
            
        }
    }
}
