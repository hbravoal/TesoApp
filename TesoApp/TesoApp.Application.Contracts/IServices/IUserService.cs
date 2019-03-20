using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesoApp.Common.Entities;

namespace TesoApp.Application.Contracts.IServices
{
    public interface IUserService
    {
        IQueryable<User> GetAllUser();
        Task<bool> Create(User User);
        Task<bool> Update(User User);
        Task<bool> Delete(User User);
        Task<User> Login(string user, string pass);
        IQueryable<User> GetAllUserByServiceType(int ServiceTypeId);

    }
}
