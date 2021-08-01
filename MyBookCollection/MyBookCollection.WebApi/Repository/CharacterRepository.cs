using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyBookCollection.WebApi.Database;
using MyBookCollection.WebApi.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookCollection.WebApi.Repository
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<CharacterRepository> logger;

        public CharacterRepository(ApplicationDbContext context, ILogger<CharacterRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<IEnumerable<Character>> GetCharacters()
        {
            var characters = await context.Characters.Include(x => x.CharacterImage).ToListAsync();
            return characters;
        }

        public async Task<IEnumerable<Character>> SearchCharacters(string searchParameter)
        {
            var characters = await context.Characters.Include(x => x.CharacterImage).
                Where(x => x.CharacterName.ToUpper().Contains(searchParameter.ToUpper())).ToListAsync();
            return characters;
        }

        public async Task<Character> GetCharacterById(int id)
        {
            var characters = await context.Characters.Include(x => x.CharacterImage).FirstOrDefaultAsync(x => x.CharacterId == id);
            return characters;
        }

        public async Task<Character> AddCharacter(Character character)
        {
            await context.Characters.AddAsync(character);
            await context.SaveChangesAsync();
            return character;
        }

        public async Task<bool> DeleteCharacter(int id)
        {
            var character = await GetCharacterById(id);
            if (character != null)
            {
                context.Characters.Remove(character);

                await context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<Character> UpdateCharacter(Character character)
        {
            //var character = await GetCharacterById();
            context.Characters.Attach(character);
            await context.SaveChangesAsync();
            return character;
        }
    }
}
