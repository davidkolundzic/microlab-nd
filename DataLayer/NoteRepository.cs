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

        

        public void Remove(int id)
        {
            this.db.Execute("DELETE FROM Notes WHERE id = @id", new { id });
        }

        public Note Update(Note note)
        {
            var sql =
                @"UPDATE notes " +
                "SET NoteDate = @NoteDate, " +
                "   Description = @Description, " +
                "   Reminder = @Reminder, " +
                "   notified = @Notified " +
                "WHERE Id = @Id";
            this.db.Execute(sql, note);
            return note;
        }
    }
    
}
