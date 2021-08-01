using Microsoft.AspNetCore.Components;
using MyBookCollection.Models;
using MyBookCollection.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookCollection.Pages
{
    public class CharactersBase:ComponentBase
    {
        public IEnumerable<CharacterDto> Characters { get; set; }

        public CharacterDto Character { get; set; }

        [Inject]
        public ICharacterService CharacterService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Character = new CharacterDto();
            Character.ImageFile = new ImageFileDto();
            Characters = (await CharacterService.GetCharacters()).ToList(); 
        }
    }
}
