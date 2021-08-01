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
        public async Task<IEnumerable<CharacterDto>> GetCharacters()
        {
            var data = await httpClient.GetJsonAsync<CharacterDto[]>("characters");
            return data;
        }
    }
}
