using FirstBlazorApp.Shared;

namespace FirstBlazorApp.Client.Services
{
    public interface IContactsService //para consumir desde el cliente
    {
        Task<IEnumerable<Contact>> GetAll();
        Task<Contact> GetDetails(int id);
        Task Save(Contact contact); //Se agrua Insert y Updaye (POST y UPDATE)
        Task Delete(int id);
    }
}
