using Business.Dtos.Request.Auth;
using Business.Dtos.Request.UserRequests;
using Business.Dtos.Response.UserResponses;
using Core.DataAccess.Paging;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IUserService
    {
        Task<IResult> Add(User user, CreateRegisterRequest request);
        Task<IResult> Update(UpdateUserRequest request);
        Task<IResult> Delete(DeleteUserRequest request);
        Task<IDataResult<User>> GetAsync(Guid userId);
        Task<IDataResult<IPaginate<GetListUserResponse>>> GetPaginatedListAsync(PageRequest pageRequest);
        Task<IDataResult<List<GetListUserResponse>>> GetListAsync();
        Task<List<OperationClaim>> GetClaims(User user);
        Task<User> GetByMail(string mail);
        Task<IResult> AddTransactionalTest(User user);
        //Task<IDataResult<User>> GetAsyncByDepartmentId(Guid departmentId);

    }
}
