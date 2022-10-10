using BlazorApp.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorApp.Client.Services.ContactService
{
    public class ContactServices : IContactService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public ContactServices(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Contact> Contacts { get; set; }= new List<Contact>();
        public List<SubCategory> SubCategories { get; set; }=new List<SubCategory>();
        public List<Category> Categories { get; set; }= new List<Category>();

        
        public async Task GetContacts()
        {
            var result = await _http.GetFromJsonAsync<List<Contact>>("/api/contacts");
            if (result != null)
                Contacts = result;   
        }
        
        public async Task<Contact> GetSingleContact(int id)
        {
            var result = await _http.GetFromJsonAsync<Contact>($"/api/contacts/{id}");
            if (result != null)
                return result;
            throw new Exception("Contact not found");
        }

       
        public async Task GetCategories()
        {
            var result = await _http.GetFromJsonAsync<List<Category>>("/api/contacts/categories");
            if (result != null)
                Categories = result;
        }
        
        public async Task GetSubCategories()
        {
            var result = await _http.GetFromJsonAsync<List<SubCategory>>("/api/contacts/subcategories");
            if (result != null)
                SubCategories = result;
        }

        public async Task CreateContact(Contact contact)
        {
            var result = await _http.PostAsJsonAsync("/api/contacts", contact);
            await SetContacts(result);
        }

        private async Task SetContacts(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Contact>>();
            Contacts = response;
            _navigationManager.NavigateTo("Contacts");
        }

        public async Task UpdateContact(Contact contact)
        {
            var result = await _http.PutAsJsonAsync($"/api/contacts/{contact.Id}", contact);
            await SetContacts(result);
        }

        public async Task DeleteContact(int id)
        {
            var result = await _http.DeleteAsync($"/api/contacts/{id}");
            await SetContacts(result); 
        }
    }
}
