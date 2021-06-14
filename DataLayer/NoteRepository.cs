using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class NoteRepository : INoteRepository
    {
        private IDbConnection db;
        public NoteRepository(string connString)
        {
            this.db = new MySqlConnection(connString);
        }

        public Note Add(Note note)
        {
            var sql =
                "INSERT INTO Notes( ContactId, NoteDate, Description, Reminder) VALUES (@ContactId, @NoteDate, @Description, @Reminder)";

            var id = this.db.Execute(sql, note);
            return note;
        }

        public Note Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<Note> GetForUser(int Id)
        {
            return this.db.Query<Note>("SELECT * FROM Notes WHERE ContactId = @Id", new { Id }).ToList();
        }

        

        public void Remove(int Id)
        {
            this.db.Execute("DELETE * FROM Note WHERE Id = @Id", new { Id });
        }

        public Note Update(Note contact)
        {
            throw new NotImplementedException();
        }
    }
}
