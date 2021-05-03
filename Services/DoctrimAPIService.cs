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
            return await _httpClient.GetJsonAsync<List<DocumentType>>("api/DocumentTypes");
        }

        public async Task PostDocumentFile(DocumentPostDTO documentPost)
        {
            var fileJson =
                new StringContent(JsonSerializer.Serialize(documentPost), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Documents", fileJson);
        }

        public async Task<List<DocumentFile>> GetAllDocuments()
        {
            return await _httpClient.GetJsonAsync<List<DocumentFile>>("api/Documents");
        }

        public async Task<DocumentPostDTO> DownloadDocument(int id)
        {
         DocumentPostDTO result = await _httpClient.GetJsonAsync<DocumentPostDTO>($"api/Documents/{id}");
            return result;       
           
        }

        public async Task<List<DocumentFile>> GetDocumentFilesFromType(DocumentType type)
        {
            try
            {               

                List<DocumentFile> result = await _httpClient.GetJsonAsync<List<DocumentFile>>($"api/Documents/ByType/{type.UniqueId}");
                return result;
            }
            catch (HttpRequestException httpEx)
            {
                return null;
                // determine error here by inspecting httpEx.Message         
            }
            
            
            
        }
    }
}
