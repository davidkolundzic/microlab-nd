using DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MailKit.Net.Smtp;
using MimeKit;
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

            Update(note);

            return note;

        }

        private Note Update(Note note)
        {
            var repository = new NoteRepository(configuration.GetConnectionString("MySqlConnection")); ;

            repository.Update(note);

            return note;
        }

        [HttpGet("removeNote")]
        public int RemoveNote(int id)
        {
            var repository = new NoteRepository(configuration.GetConnectionString("MySqlConnection")); ;
            
            repository.Remove(id);
            
            return id;


        }

        [HttpGet("getNotes")]
        public IList<Note> GetNotes(int id)
        {
            return GetUserNotes(id);
        }
        private IList<Note> GetUserNotes(int id)
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
        [HttpPost("sendMail")]
        public IList<Note> SendMail(Note note)
        {
            
            var message = new MimeMessage();
            MailboxAddress from = new MailboxAddress("David", "mail@gmail.com");
            message.From.Add(from);
            MailboxAddress to = new MailboxAddress("User", "mail@hotmail.com");
            message.To.Add(to);

            message.Subject = "This is email subject";
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = @$"<h2>Notification</h2> <h4>{note.noteDate.ToString("dd.MM")} - {note.description} </h4>";
            bodyBuilder.TextBody = "Hello world!";

            message.Body = bodyBuilder.ToMessageBody();

            // Connect
            SmtpClient client = new SmtpClient();
           // client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.SslOnConnect);
           // client.Authenticate("dakolundz@gmail.com", "VelikJeSvemir*");
            // client.Send(message);
            client.Disconnect(true);
            client.Dispose();

            Update(note);

            return GetUserNotes(note.contactId);
        }
    }
}
