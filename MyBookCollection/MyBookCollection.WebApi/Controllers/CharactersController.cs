using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBookCollection.Models;
using MyBookCollection.WebApi.DomainEntities;
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetCharacterById(int id)
        {
            var character = await characterRepository.GetCharacterById(id);
            if(character != null)
            {
                var obj = mapper.Map<CharacterDto>(character);
                return Ok(obj);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> AddCharacter(CharacterDto characterDto)
        {
            var character = mapper.Map<Character>(characterDto);
            var result = await characterRepository.AddCharacter(character);
            return CreatedAtAction(nameof(GetCharacterById), new { id = result.CharacterId }, result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCharacter(CharacterDto characterDto)
        {
            var character = mapper.Map<Character>(characterDto);
            var result = await characterRepository.UpdateCharacter(character);
            return CreatedAtAction(nameof(GetCharacterById), new { id = result.CharacterId }, result);
        }
    }
}
