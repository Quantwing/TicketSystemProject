using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TicketSystemProject.Models
{
    public class TicketModel
    {
        public int ID { get; set; }
        public string DateFormatted { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }
    }
}
