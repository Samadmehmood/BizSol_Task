using BizSol_Task.DTOs;
using BizSol_Task.Entitties;
using Microsoft.AspNetCore.Mvc;

namespace BizSol_Task.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
   
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger;
    }

    //[HttpGet(Name = "GetUsers")]
    //public IEnumerable<ResponseDto<User>> Get()
    //{
    //    var response = new ResponseDto<GetUserDto>();
    //    response.Data = new GetUserDto()
    //    {
    //        // Set the properties of GetUserDto
    //    };
    //    response.Success = true;
    //    response.Message = "User data retrieved successfully.";
    //}
}