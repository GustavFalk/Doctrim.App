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
    public class UploadTemplateFormBase : ComponentBase
    {
        public TemplatePostDTO TemplatePost { get; set; } = new TemplatePostDTO();

        public IReadOnlyList<IBrowserFile> SelectedFiles { get; set; }

        public string Message { get; set; } = "";

        [Inject]
        private IDoctrimAPIService DoctrimAPIService { get; set; }

        protected void OnInputFileChange(InputFileChangeEventArgs e)
        {
            SelectedFiles = e.GetMultipleFiles();
            StateHasChanged();
        }

        public async Task Upload()
        {

            if (SelectedFiles == null || TemplatePost.TemplateDTO.TemplateName == "")
            {
                Message = "Please fill in all fields";
            }
            else
            {
                //Takes the file extension and changes the document to a byte array
                var file = SelectedFiles[0];
                Stream stream = file.OpenReadStream();
                MemoryStream ms = new MemoryStream();
                await stream.CopyToAsync(ms);
                stream.Close();

                TemplatePost.FileByteArray = ms.ToArray();


                if (await DoctrimAPIService.PostTemplate(TemplatePost))
                {
                    Message = "Upload completed";
                }
                else
                {
                    Message = "Something went wrong with the upload";
                }



            }
        }
    }
}
