using Microsoft.AspNetCore.Components;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctrim.App.Components
{
    public class GenerateDocumentFormBase : ComponentBase
    {
        public List<DocumentTemplate> Templates { get; set; } = new List<DocumentTemplate>();

        public DocumentTemplate SelectedTemplate { get; set; } = new DocumentTemplate();

        [Inject]
        public IDoctrimAPIService DoctrimAPIService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            try
            {
                Templates = await DoctrimAPIService.GetTemplates();
            }
            catch
            { }
        }

        [Inject]
        private NavigationManager NavigationManager { get; set; }
        protected void Generate()
        {
            if (SelectedTemplate.UniqueId != Guid.Empty)
            {
                NavigationManager.NavigateTo($"https://localhost:44398/api/templates/GenerateDocument/{SelectedTemplate.UniqueId}");
            }
        }
    }
}
