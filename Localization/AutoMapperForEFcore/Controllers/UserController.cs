using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapperForEFcore.Data;
using AutoMapperForEFcore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoMapperForEFcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private AutoMapperForEFcoreContext _context;

        public UserController(AutoMapperForEFcoreContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> NewUser(AppUser model)
        {
            try
            {

                for (int x = 0; x < 9; x++)
                {
                    model.Logs.Add(new Log { Msg = "test" + x });
                }

                _context.AppUser.Add(model);
                await _context.SaveChangesAsync();
                return Ok();
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
            var result = await _context.AppUser.SingleOrDefaultAsync(c => c.Id == id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id)
        {
            var result = await _context.AppUser.Include(c => c.Logs).SingleOrDefaultAsync(c => c.Id == id);
            if (result.Logs != null)
                result.Logs.RemoveRange(0, 1);
            result.Logs.Add(new Log { Msg = "test" + Guid.NewGuid() });

            //_context.Update.
            _context.Update(result);
            await _context.SaveChangesAsync();

            return Ok(result);
        }
    }
}
