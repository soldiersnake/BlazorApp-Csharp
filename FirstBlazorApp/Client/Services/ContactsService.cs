using FirstBlazorApp.Shared;
using System.Net.Http.Json;

namespace FirstBlazorApp.Client.Services
{
    public class ContactsService : IContactsService
    {
        private readonly HttpClient _httpClient; //metodo desde que nos permite http request desde el codigo

        public ContactsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/contacts/{id}");
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Contact>>($"api/contacts/");
        }

        public async Task<Contact> GetDetails(int id)
        {
            return await _httpClient.GetFromJsonAsync<Contact>($"api/contacts/{id}");
        }

        public async Task Save(Contact contact)
        {
            if (contact.Id == 0)
                await _httpClient.PostAsJsonAsync<Contact>($"api/contacts/", contact);
            else
                await _httpClient.PutAsJsonAsync<Contact>($"api/contacts/{contact.Id}", contact);

        }
    }
}
