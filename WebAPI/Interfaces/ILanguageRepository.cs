using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    

    public interface ILanguageRepository
    {
        Task<IEnumerable<Language>> GetLanguageAsync();
        
        void AddLanguage(Language language);

        void deleteLanguage(int languageId);
        Task<Language> FindLanguage(int id);
    }
}