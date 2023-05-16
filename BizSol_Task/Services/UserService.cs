using BizSol_Task.Controllers;
using BizSol_Task.Data;
using BizSol_Task.DTOs;
using BizSol_Task.Entitties;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BizSol_Task.Services;
class UserService : IUserService
{
    private BizSolDbContext dbContext;
    private ILogger logger;
    public UserService(BizSolDbContext _dbContext,ILogger<UserService> _logger)
    {
        logger = _logger;
        this.dbContext = _dbContext;
    }

    public async Task<ResponseDto<List<User>>> GetAll()
    {
        var result=new ResponseDto<List<User>>();
        var users = dbContext.Users.AsQueryable().ToList();
        result.Success = true;
        result.Message=string.Empty;
        result.Data = users;
        return result;
    }

    public async Task<ResponseDto<List<User>>> Search(SearchRequestDto input)
    {
        var searchQuery = input.query;
        var result = new ResponseDto<List<User>>();
        var users = dbContext.Users.Where(u=> EF.Functions.Like(u.name, $"%{searchQuery}%") ||
                    EF.Functions.Like(u.email, $"%{searchQuery}%"))
        .AsQueryable().ToList();
        result.Success = true;
        result.Message = string.Empty;
        result.Data = users;
        return result;
    }

    public async Task<ResponseDto<string>> Create(CreateUserDto input)
    {
        var responseDto = new ResponseDto<string>();
        var user = new User();
        user.dateCreated = DateTime.Now;
        user.name = input.name;
        user.email = input.email;
        user.phone = input.phone;
        user.imgUrl = input.img;
        user.dateUpdated = DateTime.Now;
        try
        {
            dbContext.Add(user);
            await dbContext.SaveChangesAsync();

        }
        catch (Exception ex)
        {
            logger.LogError(ex.ToString());
            responseDto.Success = false;
            responseDto.Message = "An error occured while adding user. Please try again!";
            responseDto.Data = string.Empty;
            return responseDto;
        }
        logger.LogInformation("Added a user to db");
        responseDto.Success = true;
        responseDto.Message = "Successfully Added User";
        responseDto.Data = string.Empty;
        return responseDto;
    }

    public async Task<ResponseDto<string>> Update(UpdateUserRequestDto input)
    {
        var user = dbContext.Users.Where(a => a.id == input.id).AsTracking().FirstOrDefault();
        var responseDto = new ResponseDto<string>();
        user.dateCreated = DateTime.Now;
        user.name = input.name;
        user.email = input.email;
        user.phone = input.phone;
        user.imgUrl = input.img;
        user.dateUpdated = DateTime.Now;
        try
        {
            dbContext.Update(user);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.ToString());
            responseDto.Success = false;
            responseDto.Message = "An error occured while updating user. Please try again!";
            responseDto.Data = string.Empty;
            return responseDto;
        }
        logger.LogInformation($"Updated user with id={user.id.ToString()}");
        responseDto.Success = true;
        responseDto.Message = "Successfully updated User";
        responseDto.Data = string.Empty;
        return responseDto;
    }

    public async Task<ResponseDto<string>> Delete(IdRequestDto input)
    {
        var responseDto = new ResponseDto<string>();
        try
        {
            var user = dbContext.Users.Where(a => a.id == input.id).AsTracking().FirstOrDefault();
            dbContext.Remove(user);
            await dbContext.SaveChangesAsync();

            logger.LogInformation($"deleted user with id={user.id.ToString()}");
            responseDto.Success = true;
            responseDto.Message = "Successfully deleted User";
            responseDto.Data = string.Empty;
            return responseDto;
        }
       catch(Exception ex)
        {
            logger.LogError(ex.ToString());
            responseDto.Success = false;
            responseDto.Message = "An error occured while deleting user. Please try again!";
            responseDto.Data = string.Empty;
            return responseDto;
        }
    }
}
