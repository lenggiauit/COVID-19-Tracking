using C19Tracking.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19Tracking.API.Domain.Services
{
    public interface IUserService
    { 
        Task<User> GetById(Guid Id);
        Task<User> Authenticate(string Name, string Password);
        Task<bool> CheckExistPhoneNumber(string phoneNumber);
        Task<User> GetByPhoneNumber(string phoneNumber, string firebaseUid);
       
    }
}
