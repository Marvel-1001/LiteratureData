using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Data.Repo
{
    public class LanguageRepository : ILanguageRepository
    {
        public LanguageRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public DataContext dc { get; }

        public void AddLanguage(Language language)
        {
            dc.Languages.AddAsync(language);
        }

        public void deleteLanguage(int languageId)
        {
            var language = dc.Languages.Find(languageId);
            dc.Languages.Remove(language);
        }

        public async Task<Language> FindLanguage(int id)
        {
           return await dc.Languages.FindAsync(id);
        }

        public async Task<IEnumerable<Language>> GetLanguageAsync()
        {
            return await dc.Languages.ToListAsync();
        }

    }
}