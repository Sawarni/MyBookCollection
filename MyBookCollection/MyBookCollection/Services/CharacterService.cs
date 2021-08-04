using Microsoft.Extensions.Logging;
using MyBookCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyBookCollection.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ILogger<CharacterService> logger;
        private readonly HttpClient httpClient;

        public CharacterService(ILogger<CharacterService> logger, HttpClient httpClient)
        {
            this.logger = logger;
            this.httpClient = httpClient;
        }

        public async Task<CharacterDto> GetCharacterById(int id)
        {
            var data = await httpClient.GetJsonAsync<CharacterDto>($"characters/{id}");
            return data;
        }

        public async Task<IEnumerable<CharacterDto>> GetCharacters()
        {
            var data = await httpClient.GetJsonAsync<CharacterDto[]>("characters");
            return data;
        }

        public async Task<CharacterDto> AddUpdateCharacter(CharacterDto characterDto)
        {
            if(characterDto.CharacterId > 0)
            {
              var result =   await httpClient.PutJsonAsync<CharacterDto>("characters", characterDto);
                return result;
            }
            else
            {
                var result = await httpClient.PostJsonAsync<CharacterDto>("characters", characterDto);
                return result;
            }
        }
    }
}
