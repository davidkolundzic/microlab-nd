using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Note
    {

        public int id { get; set; }
        public int contactId { get; set; }

        public DateTime noteDate { get; set; }
        public string description{ get; set; }
        public int reminder { get; set; }

        public int notified { get; set; }

    }
}
