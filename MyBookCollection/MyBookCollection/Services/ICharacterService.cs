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
    }
}
