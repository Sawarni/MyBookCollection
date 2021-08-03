using BlazorInputFile;
using Microsoft.AspNetCore.Components;
using MyBookCollection.Models;
using MyBookCollection.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookCollection.Pages
{
    public class AddEditCharacterBase : ComponentBase
    {
        public CharacterDto Character { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public ICharacterService CharacterService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            int id = 0;
            int.TryParse(Id, out id);
            if (id == 0)
            {
                Character = new CharacterDto();
                Character.ImageFile = new ImageFileDto();
            }
            else
            {
                Character = await CharacterService.GetCharacterById(id);
                if (Character.ImageFile == null)
                    Character.ImageFile = new ImageFileDto();

            }
        }

        protected async Task UploadFileControl(IFileListEntry[] files)
        {
            var file = files.FirstOrDefault();
            if(file != null)
            {
                using (var ms = new MemoryStream())
                {
                    await file.Data.CopyToAsync(ms);
                    Character.ImageFile.ImageContent = ms.ToArray();
                    Character.ImageFile.ImageFileName = file.Name;
                    
                }
            }
        }

        protected async Task HandleCharacterSave()
        {
            var result = CharacterService.AddUpdateCharacter(Character);

            NavigationManager.NavigateTo("characters",true);
        }

    }



}
