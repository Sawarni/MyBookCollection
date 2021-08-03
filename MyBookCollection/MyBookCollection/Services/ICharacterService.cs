using MyBookCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookCollection.Services
{
   public interface ICharacterService
    {
        Task<IEnumerable<CharacterDto>> GetCharacters();
        Task<CharacterDto> GetCharacterById(int id);
        Task<bool> AddUpdateCharacter(CharacterDto characterDto);
    }
}
