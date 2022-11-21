using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Interfaces
{
    public interface IUnitOfWork
    {
        ILanguageRepository languageRepository {get; }
        IUserRepository UserRepository {get; }
        Task<bool> SaveAsync();
    }
}