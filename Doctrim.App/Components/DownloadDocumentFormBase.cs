using Microsoft.AspNetCore.Components;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrim.App.Components
{
    public class DownloadFormBase : ComponentBase
    {

        public DocumentFile Model { get; set; }

        public List<DocumentFile> DocumentFiles { get; set; } = new List<DocumentFile>();

        public List<DocumentType> DocumentTypes { get; set; } = new List<DocumentType>();

        public DocumentType SelectedType { get; set; }
        public Guid FileGuid { get; set; }

        public DateTime First { get; set; }
        public DateTime Last { get; set; }

        public SearchDTO SearchParameters { get; set; } = new SearchDTO();

        [Inject]
        private IDoctrimAPIService DoctrimAPIService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            try
            {
                var documentTask = DoctrimAPIService.GetAllDocuments();
                var typeTask = DoctrimAPIService.GetDocumentTypes();
                await Task.WhenAll(documentTask, typeTask);

                DocumentFiles = documentTask.Result.ToList();
                DocumentTypes = typeTask.Result.ToList();
            }
            catch
            {

            }
        }    

       

        protected async Task DocumentSearch()
        {
            if((SearchParameters.From != DateTime.MinValue && SearchParameters.Until == DateTime.MinValue)|| (SearchParameters.From == DateTime.MinValue && SearchParameters.Until != DateTime.MinValue))
            {
                //TODO: Both dates mus be filled in
            }
            else
            {
                if(SelectedType != null)
                {
                    SearchParameters.TypeGuid = SelectedType.UniqueId;
                }

                DocumentFiles = await DoctrimAPIService.DocumentSearch(SearchParameters);
            }

        }

        [Inject]
       private NavigationManager NavigationManager { get; set; }
        protected void DocumentDownload()
        {
            NavigationManager.NavigateTo($"https://localhost:44398/api/documents/download/{FileGuid}");
        }
    }
}
