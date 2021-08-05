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
        [Parameter]
        public CharacterDto Character { get; set; }

        protected bool ShowDialog { get; set; }

        protected string Title { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public ICharacterService CharacterService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public EventCallback<int> CharacterChanged { get; set; }

        public bool IsImageLoading { get; set; }

        protected async Task OnConfirmationChange(bool value)
        {
            
            if (value)
            {
                IsImageLoading = true;
                var result = await CharacterService.AddUpdateCharacter(Character);
                await CharacterChanged.InvokeAsync(result.CharacterId);
                IsImageLoading = false;
            }
            else
                await CharacterChanged.InvokeAsync(0);  // user has canceled the changes.
            ShowDialog = false;
        }

        public async Task ShowModal(CharacterDto character)
        {
            Character = await CharacterService.GetCharacterById(character.CharacterId);
            int id = Character.CharacterId;
            if (Character.ImageFile == null)
                Character.ImageFile = new ImageFileDto();
            if (id == 0)
            {
                Title = "Add new character";
            }
            else
            {
                Title = $"Edit character";
            }
            ShowDialog = true;
            
        }

        protected async Task UploadFileControl(IFileListEntry[] files)
        {
            var file = files.FirstOrDefault();
            if (file != null)
            {
                IsImageLoading = true;
                
                if (Character.ImageFile == null)
                    Character.ImageFile = new ImageFileDto();

                using (var ms = new MemoryStream())
                {
                    await file.Data.CopyToAsync(ms);
                    Character.ImageFile.ImageContent = ms.ToArray();
                    Character.ImageFile.ImageFileName = file.Name;
                    IsImageLoading = false;
                    

                }
            }
        }

       

    }



}
