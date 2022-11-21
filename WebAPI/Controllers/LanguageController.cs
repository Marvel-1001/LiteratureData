using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Dtos;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Authorize]
    public class LanguageController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public LanguageController(IUnitOfWork uow, IMapper mapper){
            this.uow = uow;
            this.mapper = mapper;
        }

        //GET api/language
        [HttpGet ("languages")] 
        [AllowAnonymous]
        public async Task<IActionResult> GetLanguages()
        {
            throw new UnauthorizedAccessException();
            var languages = await uow.languageRepository.GetLanguageAsync();
            
            var languagesDto = mapper.Map<IEnumerable<LanguageDto>>(languages);
            return Ok(languagesDto);  
        }

        //Post api/language/post --Post the data in JSON Format
        [HttpPost("post")]
        public async Task<IActionResult> AddLanguage(LanguageDto languageDto)
        {
            // if(!ModelState.IsValid)
            //     return BadRequest(ModelState);

            var language = mapper.Map<Language>(languageDto);
            language.LastUpdatedBy = 1;
            language.LastUpdateOn = DateTime.Now;
            uow.languageRepository.AddLanguage(language);
            await uow.SaveAsync();
            return StatusCode(201);           
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateLanguage(int id, LanguageDto languageDto)
        {
                
            if(id != languageDto.Id)
                return BadRequest("Update not allowed");
            
            var languageFromDb = await uow.languageRepository.FindLanguage(id);
            
            if (languageFromDb == null)
                return BadRequest("Update not allowed");
            
            languageFromDb.LastUpdatedBy = 1;
            languageFromDb.LastUpdateOn = DateTime.Now;
            mapper.Map(languageDto, languageFromDb);

            throw new Exception("Some unkown error occured");
            await uow.SaveAsync();
            return StatusCode(200);

        }

        [HttpPut("updateLanguageName/{id}")]
        public async Task<IActionResult> UpdateLanguage(int id, LanguageUpdateDto languageDto)
        {
            var languageFromDb = await uow.languageRepository.FindLanguage(id);
            languageFromDb.LastUpdatedBy = 1;
            languageFromDb.LastUpdateOn = DateTime.Now;
            mapper.Map(languageDto, languageFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
        }
       [HttpPatch("update/{id}")]
        public async Task<IActionResult> UpdateLanguagePatch(int id, JsonPatchDocument<Language> languageToPatch)
        {
            var languageFromDb = await uow.languageRepository.FindLanguage(id);
            languageFromDb.LastUpdatedBy = 1;
            languageFromDb.LastUpdateOn = DateTime.Now;

            languageToPatch.ApplyTo(languageFromDb, ModelState);
            await uow.SaveAsync();
            return StatusCode(200);
        }
        [HttpDelete("delete/{id}")]
          public async Task<IActionResult> deleteLanguage(int id)
        {
            uow.languageRepository.deleteLanguage(id);
            await uow.SaveAsync();
            return Ok(id);           
        }
    }
}
