using Business.Abstracts;
using Business.Dtos.Request.UserRequests;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        //[HttpPost("Add")]
        //public async Task<IActionResult> Add(User user)
        //{
        //    try
        //    {
        //        var result = await _userService.Add(user);

        //        if (!result.IsSuccess)
        //        {
        //            return BadRequest(result);
        //        }

        //        return Ok(result);

        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(500, $"Error : {ex.Message}");
        //    }
        //}

        [HttpPut("Update")]
        
        public async Task<IActionResult> Update(UpdateUserRequest request)
        {
            try
            {
                var result = await _userService.Update(request);

                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }
                return Ok(result);

            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Error : {ex.Message}");

            }

        }
        [HttpDelete("Delete")]
        
        public async Task<IActionResult> Delete(DeleteUserRequest request)
        {
            try
            {
                var result = await _userService.Delete(request);

                if (!result.IsSuccess)
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            try
            {
                var result = await _userService.GetAsync(id);

                if (!result.IsSuccess)
                {
                    return NotFound(result);
                }

                return Ok(result);

            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Error : {ex.Message}");
            }
        }

        [HttpGet("GetPagedListAsync")]  
        public async Task<IActionResult> GetPagedListAsync([FromQuery] PageRequest pageRequest)
        {
            try
            {
                var result = await _userService.GetPaginatedListAsync(pageRequest);

                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Error : {ex.Message}");
            }
        }

        [HttpGet("GetListAsync")]
        public async Task<IActionResult> GetListAsync()
        {
            try
            {
                var result = await _userService.GetListAsync();

                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Error : {ex.Message}");
            }
        }

        [HttpGet("GetByMail")]
        public async Task<IActionResult> GetByMail(string mail)
        {
           
                var result = await _userService.GetByMail(mail);

                if (result is null)
                {
                    return NotFound(result);
                }

                return Ok(result);

            
            
        }
    }
}
