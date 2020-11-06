using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.EntityFrameworkCore;
using AutoMapper.EquivalencyExpression;
using AutoMapper.QueryableExtensions;
using AutoMapperForEFcore.Data;
using AutoMapperForEFcore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AutoMapperForEFcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMapper _mapper;
        private ILogger<UserController> _logger;
        private AutoMapperForEFcoreContext _context;

        public UserController(AutoMapperForEFcoreContext context, IMapper mapper, ILogger<UserController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> NewUser(AppUserDTO model)
        {
            try
            {
                var vm = _mapper.Map<AppUser>(model);
                _context.AppUser.Add(vm);
                await _context.SaveChangesAsync();
                //_mapper.ConfigurationProvider.AssertConfigurationIsValid();
                //await _context.AppUser.Persist(_mapper).InsertOrUpdateAsync(vm);

                var result = await _mapper.ProjectTo<AppUserDTO>(_context.AppUser).OrderBy(c=>c.Id).LastOrDefaultAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> UserList()
        {
            var result = await _context.AppUser.Include(c => c.Logs).OrderBy(c => c.Id).ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> UserList(int id)
        {
            // find user and output v
            var result = await _mapper.ProjectTo<AppUserDTO>(_context.AppUser).SingleOrDefaultAsync(c => c.Id == id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(AppUserDTO model)
        {
            try
            {

                var data = await _context.AppUser.Include(c => c.Logs)
                        .AsNoTracking()
                        .SingleOrDefaultAsync(c => c.Id == model.Id);

                if (data == null)
                    return NotFound();

                //var mapper = new MapperConfiguration(cfg =>
                //{
                //    cfg.AddCollectionMappers();
                //    cfg.CreateMap<AppUserDTO, AppUser>()
                //    .EqualityComparison((odto, o) => odto.Id == o.Id);

                //    cfg.CreateMap<LogDTO, Log>()
                //    .EqualityComparison((odto, o) => odto.Id == o.Id);

                //}).CreateMapper();
                //var result = mapper.Map<AppUserDTO, AppUser>(model, data);
                await _context.AppUser.Persist(_mapper).InsertOrUpdateAsync(model);
                await _context.AppUser.Persist(_mapper).RemoveAsync(model);



                await _context.SaveChangesAsync();
                data = await _context.AppUser.Include(c => c.Logs)
                    .AsNoTracking()
                   .SingleOrDefaultAsync(c => c.Id == model.Id);

                return Ok(data);

                //_logger.LogInformation("Before");
                //foreach (var item in result.Logs)
                //{
                //    var infoMsg = $"{item.Id},{item.Msg}";
                //    _logger.LogInformation(infoMsg);
                //}

                //var vm = _mapper.Map<UpdateUserDTO>(model);

                //var data = await _context.AppUser.Include(c => c.Logs).SingleOrDefaultAsync(c => c.Id == model.Id);
                //var result = _mapper.Map<AppUser, AppUserDTO>(data, model);

                //await _context.AppUser.Persist(_mapper).InsertOrUpdateAsync(model);
                //await _context.AppUser.Persist(_mapper).RemoveAsync(model);
                //_context.Update(vm);
                //await _context.SaveChangesAsync();
                //var result = await _context.AppUser.Include(c => c.Logs).SingleOrDefaultAsync(c => c.Id == model.Id);

                //_logger.LogInformation("After");
                //foreach (var item in result.Logs)
                //{
                //    var infoMsg = $"{item.Id},{item.Msg}";
                //    _logger.LogInformation(infoMsg);
                //}

                //return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
    }
}
