using BizSol_Task.DTOs;
using BizSol_Task.Entitties;

namespace BizSol_Task.Services;

public interface IUserService
{
    Task<ResponseDto<List<User>>> GetAll();
    Task<ResponseDto<List<User>>> Search(SearchRequestDto input);
    Task<ResponseDto<string>> Create(CreateUserDto input);
    Task<ResponseDto<string>> Update(UpdateUserRequestDto input);
    Task<ResponseDto<string>> Delete(IdRequestDto input);
}
