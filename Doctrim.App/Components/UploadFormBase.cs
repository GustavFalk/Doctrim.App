using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        public DocumentType DocumentType { get; set; }

        public DocumentPostDTO PostDTO { get; set; } = new DocumentPostDTO();

        [Required]
        public byte[] FileByteArray { get; set; }

        public IReadOnlyList<IBrowserFile> selectedFiles { get; set;}

        public string Message { get; set; }


        [Inject]
        private IDoctrimAPIService DoctrimAPIService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            try { 
            DocumentTypes = (await DoctrimAPIService.GetDocumentTypes()).ToList();
            }
            catch { }

        }

        public void AddTag()
        {
            Model.Tags.Add(Tag);
            Tag = new MetadataTag();
        }

        public async Task Upload()
        {

            if (selectedFiles == null || Model.DocumentName == null || Model.UploadDate == DateTime.MinValue || DocumentType == null || Model.Tags.Count == 0)
            {
                Message = "Please fill in all fields";
            }
            else 
            { 
            //Takes the file extension and changes the document to a byte array
            var file = selectedFiles[0];
            Model.FileExtension = Path.GetExtension(file.Name);
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
               
               if( await DoctrimAPIService.PostDocumentFile(PostDTO))
                { 
                Message = "Upload completed";
                }
               else
                {
                    Message = "Something went wrong with the upload";
                }



            }
        }






        
        protected void OnInputFileChange(InputFileChangeEventArgs e)
        {
            selectedFiles = e.GetMultipleFiles();
            StateHasChanged();
        }

        
    }
}
