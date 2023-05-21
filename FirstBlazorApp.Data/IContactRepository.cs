using FirstBlazorApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstBlazorApp.Data
{
    public interface IContactsRepository
    {
        Task<IEnumerable<Contact>> GetAll(); //task lo declara asincrono
        Task<Contact> GetDetails(int id);
        Task Insert(Contact contact);
        Task Update(Contact contact);
        Task Delete(int id);
    }
}
