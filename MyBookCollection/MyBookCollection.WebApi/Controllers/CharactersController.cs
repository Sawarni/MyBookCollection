using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBookCollection.Models;
using MyBookCollection.WebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookCollection.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharactersController: ControllerBase
    {
        private readonly ILogger<CharactersController> logger;
        private readonly ICharacterRepository characterRepository;
        private readonly IMapper mapper;

        public CharactersController(ILogger<CharactersController> logger, 
            ICharacterRepository characterRepository, IMapper mapper)
        {
            this.logger = logger;
            this.characterRepository = characterRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetCharacters()
        {
            var characters = await characterRepository.GetCharacters();
            var characterDtos = mapper.Map<IEnumerable<CharacterDto>>(characters);
            return Ok(characterDtos);
        }
    }
}
