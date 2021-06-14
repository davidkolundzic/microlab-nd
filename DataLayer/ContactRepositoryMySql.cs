using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DataLayer
{
    public class ContactRepositoryMySql: IContactRepository
    {
        private IDbConnection db;
        public ContactRepositoryMySql(string connString)
        {
            this.db = new MySqlConnection(connString);
        }

        public Contact Add(Contact contact)
        {
            var sql =
                "INSERT INTO Contacts(FirstName, LastName, Email, Company, Title) VALUES (@FirstName, @LastName, @Email, @Company, @Title)";
          
            var id = this.db.Execute(sql, contact);
            
            return contact;
        }

        public Contact Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetAll()
        {
            return this.db.Query<Contact>("SELECT * FROM Contact").ToList();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Contact Update(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
