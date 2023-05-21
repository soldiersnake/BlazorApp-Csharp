using Dapper;
using FirstBlazorApp.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstBlazorApp.Data
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly IDbConnection _dbConnection;

        public ContactsRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task Delete(int id)
        {
            var sql = @"DELETE FROM Contacts
                        WHERE Id = @Id ";

            await _dbConnection.QueryFirstOrDefaultAsync<Contact>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            var sql = @"SELECT id, FirstName, LastName, Phone, Address
                        FROM Contacts ";

            return await _dbConnection.QueryAsync<Contact>(sql, new { });
        }

        public async Task<Contact> GetDetails(int id)
        {
            var sql = @"SELECT id, FirstName, LastName, Phone, Address
                        FROM Contacts
                        WHERE Id = @Id ";

            return await _dbConnection.QueryFirstOrDefaultAsync<Contact>(sql, new { Id = id });
        }

        public async Task Insert(Contact contact)
        {
            var sql = @"INSERTO TO (FirstName, LastName, Phone, Address)
                        VALUES (@FirstName, @LastName, @Phone, @Address)";

            await _dbConnection.ExecuteAsync(sql, new
            {
                contact.FirstName,
                contact.LastName,
                contact.Phone,
                contact.Address
            });
        }

        public async Task Update(Contact contact)
        {
            string sql = @"UPDATE Contacts
                        SET FirstName = @FirstName,
                            Phone = @Phone,
                            Address = @Address,
                        WHERE Id = @Id ";

            await _dbConnection.ExecuteAsync(sql, new
            {
                contact.FirstName,
                contact.LastName,
                contact.Phone,
                contact.Address,
                contact.Id
            });
        }
    }
}
