using DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microlab_nd.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public NotesController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet("getall")]
        public IList<Contact> GetAll()
        {
            var repository = new ContactRepositoryMySql(configuration.GetConnectionString("MySqlConnection"));
            //var repository = CreateRepository();
            var contacts = repository.GetAll();

            return contacts;
        }

        [HttpPost("create")]
        public Contact Create(Contact contact)
        {
            var repository = new ContactRepositoryMySql(configuration.GetConnectionString("MySqlConnection")); ;
            
            repository.Add(contact);
            
            return contact;


        }
        [HttpPost("createNote")]
        public Note CreateNote(Note note)
        {
            var repository = new NoteRepository(configuration.GetConnectionString("MySqlConnection")); ;
            
            repository.Add(note);
            
            return note;


        }

        [HttpPost("updateNote")]
        public Note UpdateNote(Note note)
        {
            var repository = new NoteRepository(configuration.GetConnectionString("MySqlConnection")); ;

            repository.Add(note);

            return note;


        }



        [HttpPost("removeNote")]
        public int RemoveNote(int id)
        {
            var repository = new NoteRepository(configuration.GetConnectionString("MySqlConnection")); ;
            
            repository.Remove(id);
            
            return id;


        }

        [HttpGet("getNotes")]
        public IList<Note> GetNotes(int id)
        {
            var repository = new NoteRepository(configuration.GetConnectionString("MySqlConnection")); ;
            
            return repository.GetForUser(id);

        }

        private IContactRepository CreateRepository()
        {
            //var cr = new ContactRepostiory("server=(localdb)\\ProjectsV13;database=microlabdb;Trusted_Connection=True;MultipleActiveResultSets=true");
            var cr = new ContactRepostiory(configuration.GetConnectionString("DefaultConnection"));
            //var cr = new ContactRepositoryMySql(configuration.GetConnectionString("MySqlConnection"));
            return cr;
        }
    }
}
