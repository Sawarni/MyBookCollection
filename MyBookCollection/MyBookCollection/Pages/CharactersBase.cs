using Microsoft.AspNetCore.Components;
using MyBookCollection.Models;
using MyBookCollection.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookCollection.Pages
{
    public class CharactersBase : ComponentBase
    {


        public string Title { get; set; }
        public List<CharacterDto> Characters { get; set; }

        public CharacterDto Character { get; set; }

        [Inject]
        public ICharacterService CharacterService { get; set; }

        protected AddEditCharacterBase AddEditCharacter { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Character = new CharacterDto();
            Character.ImageFile = new ImageFileDto();
            Characters = (await CharacterService.GetCharacters()).ToList();
        }

        protected async Task AddEditClick(CharacterDto character)
        {
           await AddEditCharacter.ShowModal(character);
        }

        protected async Task HandleCharacterChanged(int characterId)
        {
            if (characterId > 0)
            {
                var characterDto = await CharacterService.GetCharacterById(characterId);


                if (Characters.Any(x => characterDto.CharacterId == x.CharacterId))
                {
                    var charact = Characters.First(x => x.CharacterId == characterDto.CharacterId);
                    charact = characterDto;
                }
                else
                {
                    Characters.Add(characterDto);
                }
            }
        }
    }
}
