using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrim.App.Components
{
    public class IndexNavComponentBase : ComponentBase
    {

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        protected void NavUpload()
        {
            NavigationManager.NavigateTo("UploadDocument");
        }

        protected void NavDownload()
        {
            NavigationManager.NavigateTo("DownloadDocument");
        }

        protected void NavGenerate()
        {
            NavigationManager.NavigateTo("GenerateDocument");
        }
    }
}
