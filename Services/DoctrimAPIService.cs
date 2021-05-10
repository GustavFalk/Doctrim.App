using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.IO;

namespace Services
{
    public class DoctrimAPIService : IDoctrimAPIService
    {
        private readonly HttpClient _httpClient;

        public DoctrimAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DocumentType>> GetDocumentTypes()
        {
            try
            { 
            return await _httpClient.GetJsonAsync<List<DocumentType>>("api/DocumentTypes");
            }
            catch (HttpRequestException httpEx)
            {
                return null;
                // determine error here by inspecting httpEx.Message
                // TODO: add errorhandling
            }

        }

        public async Task<bool> PostDocumentFile(DocumentPostDTO documentPost)
        {
            try
            {
                var fileJson =
                    new StringContent(JsonSerializer.Serialize(documentPost), Encoding.UTF8, "application/json");

                 await _httpClient.PostAsync("api/Documents", fileJson);
                return true;

            }
            catch (HttpRequestException httpEx)
            {

                return false;
            }
        }

        public async Task<bool> PostTemplate(TemplatePostDTO templatePost)
        {
            try
            {
                var templateJson =
                    new StringContent(JsonSerializer.Serialize(templatePost), Encoding.UTF8, "application/json");

                await _httpClient.PostAsync("api/Templates", templateJson);
                return true;

            }
            catch (HttpRequestException httpEx)
            {

                return false;
            }
        }

        public async Task<List<DocumentFile>> GetAllDocuments()
        {
            try 
            { 

            return await _httpClient.GetJsonAsync<List<DocumentFile>>("api/Documents");

            }
            catch (HttpRequestException httpEx)
            {
                return null;
                // determine error here by inspecting httpEx.Message
                // TODO: add errorhandling
            }
        }

        public async Task<DocumentPostDTO> DownloadDocument(Guid UniqueId)
        {            
         return await _httpClient.GetJsonAsync<DocumentPostDTO>($"api/Documents/{UniqueId}");
             
           
        }

        public async Task<List<DocumentFile>> GetDocumentFilesFromType(DocumentType type)
        {
            try
            {             

                return await _httpClient.GetJsonAsync<List<DocumentFile>>($"api/Documents/ByType/{type.UniqueId}");
                
            }
            catch (HttpRequestException httpEx)
            {
                return null;
                // determine error here by inspecting httpEx.Message
                // TODO: add errorhandling
            }



        }

        public async Task<List<DocumentFile>> GetDocumentFilesBetweenDates(DateTime first, DateTime last)
        {
            try
            {
                return await _httpClient.GetJsonAsync<List<DocumentFile>>($"api/Documents/BetweenDates/{first}&&{last}");                
                
            }
            catch (HttpRequestException httpEx)
            {
                return null;
                // determine error here by inspecting httpEx.Message
                // TODO: add errorhandling
            }
        }

        public async Task<List<DocumentFile>> GetDocumentFromTag(string tag)
        {
            try
            {
                return await _httpClient.GetJsonAsync<List<DocumentFile>>($"api/Documents/FromTag/{tag}");

            }
            catch (HttpRequestException httpEx)
            {
                return null;
                // determine error here by inspecting httpEx.Message
                // TODO: add errorhandling
            }
        }

        public async Task<List<DocumentFile>> DocumentSearch(SearchDTO searchParameters)
        {
            try
            {
                //TODO: fix this code. API wont accept "searchParamters" directly in the query.
                return await _httpClient.GetJsonAsync<List<DocumentFile>>
                    ($"api/Documents/Search?TypeGuid={searchParameters.TypeGuid}&From={searchParameters.From}" +
                    $"&Until={searchParameters.Until}&TagName={searchParameters.TagName}&LegalEntityGuid={searchParameters.LegalEntityGuid}");

            }
           catch (HttpRequestException httpEx)
            {
                return null;
                // determine error here by inspecting httpEx.Message
                // TODO: add errorhandling
            }

        }

        public async Task<List<DocumentTemplate>> GetTemplates()
        {
            try
            {

                return await _httpClient.GetJsonAsync<List<DocumentTemplate>>("api/Templates");

            }
            catch (HttpRequestException httpEx)
            {
                return null;
                // determine error here by inspecting httpEx.Message
                // TODO: add errorhandling
            }
        }
    }
}
