using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataLayer
{
    public class ContactRepostiory : IContactRepository
    {
        private IDbConnection db;
        public ContactRepostiory(string connString)
        {
            //this.db = new SqlConnection(connString);
            this.db = new SqlConnection(connString);

        }

        public Contact Add(Contact contact)
        {
            var sql =
                 "INSERT INTO Contacts(FirstName, LastName, Email, Company, Title) VALUES (@FirstName, @LastName, @Email, @Company, @Title)";
                 //"SELECT LAST_INSERT_ID()";
            var id = this.db.Execute(sql, contact);
           // contact.Id = id;
            return contact;
        }

        public Contact Find(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Contact> GetAll()
        {
            return this.db.Query<Contact>("SELECT * FROM Contacts").ToList();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public Contact Update(Contact contact)
        {
            throw new System.NotImplementedException();
        }
    }
}
