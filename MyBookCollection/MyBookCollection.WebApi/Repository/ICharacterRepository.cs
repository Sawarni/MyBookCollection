using MyBookCollection.WebApi.DomainEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBookCollection.WebApi.Repository
{
    public interface ICharacterRepository
    {
        Task<Character> AddCharacter(Character character);
        Task<bool> DeleteCharacter(int id);
        Task<Character> GetCharacterById(int id);
        Task<IEnumerable<Character>> GetCharacters();
        Task<IEnumerable<Character>> SearchCharacters(string searchParameter);
        Task<Character> UpdateCharacter(Character character);
    }
}