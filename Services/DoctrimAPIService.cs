﻿using Microsoft.AspNetCore.Components;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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

        public async Task<DocumentFile> PostDocumentFile(DocumentFile file)
        {

            int id = 1;

           //await _httpClient.PostJsonAsync("api/Documents", file);

            var fileJson =
                new StringContent(JsonSerializer.Serialize(id), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Documents", fileJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<DocumentFile>(await response.Content.ReadAsStreamAsync());
            }

            return null;




        }
    }
}