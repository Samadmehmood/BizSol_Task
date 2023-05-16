using BizSol_Task.DTOs;
using BizSol_Task.Entitties;
using BizSol_Task.Services;
using Microsoft.AspNetCore.Mvc;

namespace BizSol_Task.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
   
    private readonly ILogger<UsersController> _logger;
    private readonly IUserService _userService;
    public UsersController(ILogger<UsersController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseDto<List<User>>>> GetAllUsers()
    {
        var response = await _userService.GetAll();
        return Ok(response);
    }

    [HttpGet("search")]
    public async Task<ActionResult<ResponseDto<List<User>>>> SearchUsers([FromQuery] SearchRequestDto input)
    {
        var response = await _userService.Search(input);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ResponseDto<string>>> CreateUser(CreateUserDto input)
    {
        var response = await _userService.Create(input);
        if (!response.Success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<ResponseDto<string>>> UpdateUser(UpdateUserRequestDto input)
    {
        var response = await _userService.Update(input);
        if (!response.Success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ResponseDto<string>>> DeleteUser(IdRequestDto input)
    {
        var response = await _userService.Delete(input);
        if (!response.Success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }
}