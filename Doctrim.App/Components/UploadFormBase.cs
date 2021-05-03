using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrim.App.Components
{
    public class UploadFormBase : ComponentBase
    {

        public DocumentFile Model { get; set; } = new DocumentFile();

        public List<DocumentType> DocumentTypes { get; set; } = new List<DocumentType>();

        public MetadataTag Tag { get; set; } = new MetadataTag();

        public DocumentType DocumentType { get; set; }

        public DocumentPostDTO PostDTO { get; set; } = new DocumentPostDTO();

        public byte[] FileByteArray { get; set; }




        [Inject]
        private IDoctrimAPIService DoctrimAPIService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            DocumentTypes = (await DoctrimAPIService.GetDocumentTypes()).ToList();

        }

        public void AddTag()
        {
            Model.Tags.Add(Tag);
            Tag = new MetadataTag();
        }

        public async Task Upload()
        {
            //Changes the document to a byte array
            var file = selectedFiles[0];
            Stream stream = file.OpenReadStream();
            MemoryStream ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            stream.Close();

            FileByteArray = ms.ToArray();


            //assigns unique identifier to document
            Model.UniqueId = Guid.NewGuid();
            Model.TypeGuid = DocumentType.UniqueId;

            //sends object through POST method
            PostDTO.DocumentFile = Model;
            PostDTO.FileByteArray = FileByteArray;
            await DoctrimAPIService.PostDocumentFile(PostDTO);
        }






        private IReadOnlyList<IBrowserFile> selectedFiles;
        protected void OnInputFileChange(InputFileChangeEventArgs e)
        {
            selectedFiles = e.GetMultipleFiles();
            StateHasChanged();
        }

        
    }
}
